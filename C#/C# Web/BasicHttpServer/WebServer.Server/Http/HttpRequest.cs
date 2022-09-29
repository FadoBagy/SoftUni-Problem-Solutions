namespace WebServer.Server.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpRequest
    {
        private const string NewLine = "\r\n";

        public HttpMethod Method { get; private set; }

        public string Url { get; private set; }

        public HttpHeaderCollection Headers { get; private set; }

        public string Body { get; private set; }

        public static HttpRequest Parse(string request) 
        {
            if (request == String.Empty)
            {
                Console.WriteLine(" #Empty request");
                return null;
            }

            var lines = request.Split(NewLine);
            var startLine = lines.First().Split(" ");

            var method = ParseHttpMethod(startLine[0]);
            var url = startLine[1];
            var header = ParseHttpHeader(lines.Skip(1));

            int headerCollectionCount = header.Count();
            var body = String.Join(NewLine,
                lines.Skip(headerCollectionCount + 2).ToArray());

            return new HttpRequest
            {
                Method = method,
                Url = url,
                Headers = header,
                Body = body
            };
        }

        private static HttpMethod ParseHttpMethod(string method) 
            => method.ToUpper() switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                "DELETE" => HttpMethod.Delete,
                _ => throw new InvalidOperationException($"Method '{method}' is not supported.")
            };

        private static HttpHeaderCollection ParseHttpHeader(IEnumerable<string> headerLines)
        {
            var headersCollection = new HttpHeaderCollection();
            foreach (var headerLine in headerLines)
            {
                if (headerLine == String.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(':', 2);
                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request headers are not valid.");
                }

                var header = new HttpHeader
                {
                    Name = headerParts[0],
                    Value = headerParts[1].Trim()
                };
                headersCollection.Add(header);
            }

            return headersCollection;
        }
    }
}
