using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace EchoArenaStats.Methods
{
    public static class CreateServer
    {
        private static readonly HttpListener HttpListener = new HttpListener();
        private static Thread responseThread;


        public static void StartServer()
        {
            Console.WriteLine("Starting server...");
            HttpListener.Prefixes.Add("http://localhost:5000/");
            HttpListener.Prefixes.Add("http://localhost:5000/home/");
            HttpListener.Start(); 
            Console.WriteLine("Server started.");
            responseThread = new Thread(ResponseThread);
            responseThread.Start(); 
            
        }

        private static HttpListenerContext context;
        private static void ResponseThread()
        {
            while (true)
            {
                const string path = "C:\\Users\\Public\\Documents\\EchoStatsLogger\\savedData.json";
                var toWrite = Convert.ToString(File.ReadAllText(path));
                // Now, you'll find the request URL in context.Request.Url
                var responseArray = Encoding.UTF8.GetBytes(toWrite); // get the bytes to response
                context = HttpListener.GetContext(); // get a context
                context.Response.OutputStream.Write(responseArray, 0,
                    responseArray.Length); // write bytes to the output stream
                context.Response.KeepAlive = false; // set the KeepAlive bool to false
                context.Response.Close(); // close the connection
                Console.WriteLine("Server data has been requested.");
                ReloadPage();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private static void ReloadPage()
        {
            var contextNew = HttpListener.GetContext();
            contextNew.Response.Redirect("http://localhost:5000/");
            Thread.Sleep(500);
        }
        
    }
    
    
}