using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace EchoStats.Methods
{
    public static class PlayerInfo
    {
        public static void DisplayPlayerInfo()
        {
            var baseData = File.ReadAllText(Echo.SettingsPath);
            dynamic data = JsonConvert.DeserializeObject(baseData);
            Thread.Sleep(500);
            // bool runCheck = JsonConvert.SerializeObject(data?["hasRunBefore"]) != "false";
            var username = JsonConvert.SerializeObject(data?["Username"]);
            string user = username.Substring(1, username.Length - 2);
            string ip = Convert.ToString(JsonConvert.SerializeObject(data?["IP"]));
            var platform = "";
            platform = ip.Substring(1, ip.Length -2) == "127.0.0.1" ? "Rift" : "Quest \nIP: " + ip.Substring(1, ip.Length-2);
            
            Console.WriteLine("Username: " + user);
            Console.WriteLine("Platform: " + platform);
        }
    }
}