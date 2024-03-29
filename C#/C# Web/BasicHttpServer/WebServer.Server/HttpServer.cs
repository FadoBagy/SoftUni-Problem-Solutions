﻿namespace WebServer.Server
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using WebServer.Server.Http;

    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;

        public HttpServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            listener = new TcpListener(this.ipAddress, this.port);
        }

        public async Task Start() 
        {
            listener.Start();
            Console.WriteLine($" #Server started on port {port}...");

            while (true)
            {
                Console.WriteLine(" #Listening for requests...");
                // Connection to the browser
                var connection = await listener.AcceptTcpClientAsync();
                // Information send
                var networkStream = connection.GetStream();

                var requestText = await ReadRequest(networkStream);
                Console.WriteLine(requestText);

                var request = HttpRequest.Parse(requestText);

                await WriteResponse(networkStream);

                connection.Close();
            }
        }

        private static async Task<string> ReadRequest(NetworkStream networkStream) 
        {
            // Saving the request by parts
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];
            int totalBytes = 0;
            var requestBuilder = new StringBuilder();

            do
            {
                var byteRead = await networkStream.ReadAsync(buffer, 0, bufferLength);
                totalBytes += byteRead;
                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, byteRead));

            }
            while (networkStream.DataAvailable);

            return requestBuilder.ToString().TrimEnd();
        }

        private static async Task WriteResponse(NetworkStream networkStream)
        {
            var content = "Hello from the сървър!";
            var contentLength = Encoding.UTF8.GetByteCount(content);
            var response = $@"HTTP/1.1 200 OK
Server: My Web Server
Date: {DateTime.UtcNow.ToString("r")}
Content-Length: {contentLength}
Content-Type: text/plain; charset=UTF-8 

{content}";
            var responseBytes = Encoding.UTF8.GetBytes(response);
            await networkStream.WriteAsync(responseBytes);
        }
    }
}
