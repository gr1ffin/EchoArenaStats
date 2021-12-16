﻿using Newtonsoft.Json;

namespace EchoStatsWeb.Methods
{
    public class PlayerData
    {
        private static readonly int Team = PlayerLocation.TeamNum;
        private static readonly int Player = PlayerLocation.PlayerNum;
        public static void PlayerStats()
        {
            var settingsData = File.ReadAllText("C:\\Users\\Public\\Documents\\EchoStatsLogger\\settings.json");
            dynamic dataB = JsonConvert.DeserializeObject(settingsData);
            var baseData = GetUrlC.GetUrl("http://" + JsonConvert.SerializeObject(dataB?["IP"]) + "/session");
            dynamic data = JsonConvert.DeserializeObject(baseData);
            Thread.Sleep(500);

            string playerName = JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["name"]);
            int points = JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["stats"]["points"]);
            int assists = JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["stats"]["assists"]);
            int saves = JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["stats"]["saves"]);
            int stuns = JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["stats"]["stuns"]);
            var otherTeam = 0;
            switch (Team)
            {
                case 0:
                    otherTeam = 1;
                    break;
                case 1:
                    otherTeam = 0;
                    break;
            }

            bool didWin = JsonConvert.SerializeObject(data?["teams"][Team]["stats"]["points"]) >
                          JsonConvert.SerializeObject(data?["teams"][otherTeam]["stats"]["points"]);

            SaveData.SaveStats(points, assists, saves, stuns, didWin);

        }
    }
}