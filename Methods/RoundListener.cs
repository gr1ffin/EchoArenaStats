using System;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace EchoStats.Methods
{
    public static class RoundListener
    {

        public static int LocalTeam = PlayerLocation.TeamNum;
        public static int LocalPlayer = PlayerLocation.PlayerNum;

        public static void GameStatus()
        {

            var settingsData = File.ReadAllText(Echo.SettingsPath);
            dynamic dataB = JsonConvert.DeserializeObject(settingsData);
            string ip = Convert.ToString(JsonConvert.SerializeObject(dataB?["IP"]));
            string parsedIp = ip.Substring(1, ip.Length - 2);
            // var baseData = GetUrlC.GetUrl("http://" + ip.Substring(1, ip.Length -2) + ":6721/session");
            // dynamic data = JsonConvert.DeserializeObject(baseData);
            // Thread.Sleep(500);
            // var baseData2 = GetUrlC.GetUrl("http://" + ip.Substring(1, ip.Length -2) + ":6721/session");
            // dynamic data2 = JsonConvert.DeserializeObject(baseData2);
            bool ongoing = true;
            // if (JsonConvert.SerializeObject(data?["game_status"]) ==
            //     JsonConvert.SerializeObject(data2?["game_status"])) return;
            //
            // if (JsonConvert.SerializeObject(data2?["game_status"]) != "post_match") return;

            while (true)
            {
                var baseData = GetUrlC.GetUrl("http://" + parsedIp + ":6721/session");
                dynamic data = JsonConvert.DeserializeObject(baseData);
                Thread.Sleep(500);
                var baseData2 = GetUrlC.GetUrl("http://" + parsedIp + ":6721/session");
                dynamic data2 = JsonConvert.DeserializeObject(baseData2);
                var takeData = JsonConvert.SerializeObject(data2?["game_status"]);
                if (takeData.Substring(1, takeData.Length -2) == "post_match")
                {
                    Console.WriteLine("Post Match detected");
                    PlayerLocation.FindPlayer();
                    PlayerData.PlayerStats();
                    break;
                }
                else
                {
                    Console.WriteLine(JsonConvert.SerializeObject(data2?["game_status"]));
                    Thread.Sleep(5000);
                }



            }
        }
    }
}