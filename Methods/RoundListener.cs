using Newtonsoft.Json;

namespace Methods
{
    public class RoundListener
    {

        public static int LocalTeam = PlayerLocation.TeamNum;
        public static int LocalPlayer = PlayerLocation.PlayerNum;
        public static void GameStatus()
        {

            var settingsData = File.ReadAllText("C:\\Users\\Public\\Documents\\EchoStatsLogger\\settings.json");
            dynamic dataB = JsonConvert.DeserializeObject(settingsData);
            var baseData = GetUrlC.GetUrl("http://" + JsonConvert.SerializeObject(dataB?["IP"]) + "/session");
            dynamic data = JsonConvert.DeserializeObject(baseData);
            System.Threading.Thread.Sleep(500);
            var baseData2 = GetUrlC.GetUrl("http://" + JsonConvert.SerializeObject(dataB?["IP"]) + "/session");
            dynamic data2 = JsonConvert.DeserializeObject(baseData2);
            if (JsonConvert.SerializeObject(data?["game_status"]) ==
                JsonConvert.SerializeObject(data2?["game_status"])) return;
            if (JsonConvert.SerializeObject(data2?["game_status"]) == "post_match") {
                PlayerLocation.FindPlayer();
                PlayerData.PlayerStats();
            }
        }
    }
}