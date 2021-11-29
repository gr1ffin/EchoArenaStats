using System;
using Newtonsoft.Json;

namespace EchoArenaStats.Methods
{
    public static class PlayerLocation
    {
        public static int PlayerNum;
        public static int TeamNum;
        private static string _clientName;

        public static void FindPlayer()
        {
            var baseData = GetUrlC.GetUrl("http://localhost:5000");
            dynamic data = JsonConvert.DeserializeObject(baseData);
            System.Threading.Thread.Sleep(500);
            if (data != null) {
                _clientName = JsonConvert.SerializeObject((object) data["client_name"]);
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