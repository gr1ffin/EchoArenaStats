using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace EchoStats.Methods
{
    public static class PlayerData
    {
        private static readonly int Team = PlayerLocation.TeamNum;
        private static readonly int Player = PlayerLocation.PlayerNum;
        public static void PlayerStats()
        {
            var settingsData = File.ReadAllText(Echo.SettingsPath);
            dynamic dataB = JsonConvert.DeserializeObject(settingsData);
            string ip = Convert.ToString(JsonConvert.SerializeObject(dataB?["IP"]));
            string parsedIp = ip.Substring(1, ip.Length - 2);
            var baseData = GetUrlC.GetUrl("http://" + parsedIp + ":6721/session");
            dynamic data = JsonConvert.DeserializeObject(baseData);
            Thread.Sleep(500);

            string playerName = JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["name"]);
            int points = Int32.Parse(JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["stats"]["points"]));
            int assists = Int32.Parse(JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["stats"]["assists"]));
            int saves = Int32.Parse(JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["stats"]["saves"]));
            int stuns = Int32.Parse(JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["stats"]["stuns"]));
            var otherTeam = Team switch
            {
                0 => 1,
                1 => 0,
                _ => 0
            };

            bool didWin = Int32.Parse(JsonConvert.SerializeObject(data?["teams"][Team]["stats"]["points"])) >
                          Int32.Parse(JsonConvert.SerializeObject(data?["teams"][otherTeam]["stats"]["points"]));

            SaveData.SaveStats(points, assists, saves, stuns, didWin);

        }
    }
}