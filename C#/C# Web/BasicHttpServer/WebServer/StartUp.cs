namespace WebServer
{
    using System.Threading.Tasks;
    using WebServer.Server;

    public class StartUp
    {
        public static async Task Main()
        {
            // localhost ip + port
            // http://127.0.0.1:8080
            // http://localhost:8080

            var server = new HttpServer("127.0.0.1", 8080);

            await server.Start();
        }
    }
}
