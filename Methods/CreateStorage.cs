using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EchoStats.Methods
{
    public static class CreateStorage
    {
        
        public static void CreateFile()
        {
            DateTime date = DateTime.Today;
            var initialStorage = new JObject(
                new JProperty("points", 0),
                new JProperty("assists", 0),
                new JProperty("saves", 0),
                new JProperty("stuns", 0),
                new JProperty("wins", 0),
                new JProperty("losses", 0),
                new JProperty("total", 0),
                new JProperty("winrate", 00.00),
                new JProperty("hasRunBefore", false),
                new JProperty("date", date.ToString("d")));
            
            
            if (File.Exists(Echo.DataPath)) Console.WriteLine("File Already Exists");
            else
            {
                using StreamWriter file = File.CreateText(Echo.DataPath);
                using JsonTextWriter writer = new JsonTextWriter(file);
                initialStorage.WriteTo(writer);
            }
        }

    }
}