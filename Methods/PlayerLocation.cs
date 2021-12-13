using System;
using Newtonsoft.Json;

namespace Methods
{
    public static class PlayerLocation
    {
        public static int PlayerNum;
        public static int TeamNum;
        private static string? _clientName;

        public static void FindPlayer()
        {
            var baseData = GetUrlC.GetUrl("http://127.0.0.1:6721/session");
            dynamic data = JsonConvert.DeserializeObject(baseData);
            System.Threading.Thread.Sleep(500);
            var settingsData = File.ReadAllText("C:\\Users\\Public\\Documents\\EchoStatsLogger\\settings.json");
            dynamic dataB = JsonConvert.DeserializeObject(settingsData);
            if (data != null) {
                _clientName = JsonConvert.SerializeObject((object)dataB["username"]);
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