using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace EchoStats.Methods
{
    public static class PlayerLocation
    {
        public static int PlayerNum;
        public static int TeamNum;
        private static string? _clientName;

        public static void FindPlayer()
        {
            var settingsData = File.ReadAllText(Echo.SettingsPath);
            dynamic dataB = JsonConvert.DeserializeObject(settingsData);
            string ip = Convert.ToString(JsonConvert.SerializeObject(dataB?["IP"]));
            string parsedIp = ip.Substring(1, ip.Length - 2);
            var baseData = GetUrlC.GetUrl("http://" + parsedIp + ":6721/session");
            dynamic data = JsonConvert.DeserializeObject(baseData);
            Thread.Sleep(500);

            if (data != null)
            {
                _clientName = JsonConvert.SerializeObject((object)dataB?["username"]);
                for (var a = 0; a < 2; a++)
                {
                    for (var b = 0; b < 4; b++)
                    {
                        string obj = JsonConvert.SerializeObject(data["teams"][a]["players"][b]);
                        string toCheck = JsonConvert.SerializeObject(data["teams"][a]["players"][b]["name"]);
                        if (obj == null) continue;
                        if (toCheck == _clientName) TeamNum = a; PlayerNum = b;
                        break;
                    }
                }
            }
            Console.WriteLine("Team: " + TeamNum + " Player: " + PlayerNum);
        }
    }
}