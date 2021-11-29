using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace EchoArenaStats.Methods
{
    public static class CreateServer
    {
        private static readonly HttpListener HttpListener = new HttpListener();

        public static void StartServer()
        {
            Console.WriteLine("Starting server...");
            HttpListener.Prefixes.Add("http://localhost:5000/"); // add prefix "http://localhost:5000/"
            HttpListener.Start(); // start server (Run application as Administrator!)
            Console.WriteLine("Server started.");
            var responseThread = new Thread(ResponseThread);
            responseThread.Start(); // start the response thread
        }

        private static void ResponseThread()
        {
            
            while (true)
            {
                const string path = "C:\\Users\\agent\\RiderProjects\\EchoArenaStats\\stats.json";
                var toWrite = Convert.ToString(File.ReadAllText(path));
                // Now, you'll find the request URL in context.Request.Url
                var responseArray = Encoding.UTF8.GetBytes(toWrite); // get the bytes to response
                var context = HttpListener.GetContext(); // get a context
                context.Response.OutputStream.Write(responseArray, 0, responseArray.Length); // write bytes to the output stream
                context.Response.KeepAlive = false; // set the KeepAlive bool to false
                context.Response.Close(); // close the connection
                Console.WriteLine("Server data has been requested.");
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}