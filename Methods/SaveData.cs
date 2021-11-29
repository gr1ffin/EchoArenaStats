using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EchoArenaStats.Methods
{

    public static class SaveData 
    {
        public static void SaveStats(int points, int assists, int saves, int stuns, bool didWin)
        {
            var baseData = File.ReadAllText("C:\\Users\\Public\\Documents\\EchoStatsLogger\\savedData.json");
            dynamic data = JsonConvert.DeserializeObject(baseData);
            System.Threading.Thread.Sleep(500);

            var oldPoints = JsonConvert.SerializeObject(data?["points"]);
            var oldAssists = JsonConvert.SerializeObject(data?["saves"]);
            var oldSaves = JsonConvert.SerializeObject(data?["stuns"]);
            var oldStuns = JsonConvert.SerializeObject(data?["assists"]);
            // Separate 
            var oldTotal = JsonConvert.SerializeObject(data?["total"]);
            var oldWinrate = JsonConvert.SerializeObject(data?["winrate"]);
            var oldLosses = JsonConvert.SerializeObject(data?["losses"]);
            var oldWins = JsonConvert.SerializeObject(data?["wins"]);

            var newTotal = oldTotal;

            if (didWin) {var newWins = oldWins + 1; newTotal += 1;}
            else {var newLosses = oldLosses + 1; newTotal += 1;}

            var newPoints = oldPoints + points;
            var newAssists = oldAssists + assists;
            var newSaves = oldSaves + saves;
            var newStuns = oldStuns + stuns;

        }
    }
    
}