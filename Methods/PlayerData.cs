using Newtonsoft.Json;

namespace EchoArenaStats.Methods
{
    public class PlayerData
    {
        private static readonly int Team = PlayerLocation.TeamNum;
        private static readonly int Player = PlayerLocation.PlayerNum;
        public static void PlayerStats()
        {
            var baseData = GetUrlC.GetUrl("http://localhost:5000");
            dynamic data = JsonConvert.DeserializeObject(baseData);
            System.Threading.Thread.Sleep(500);

            string playerName = JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["name"]);
            int points = JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["stats"]["points"]);
            int assists = JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["stats"]["assists"]);
            int saves = JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["stats"]["saves"]);
            int stuns = JsonConvert.SerializeObject(data?["teams"][Team]["players"][Player]["stats"]["stuns"]);

            SaveData.SaveStats(points, assists, saves, stuns);

        }
    }
}