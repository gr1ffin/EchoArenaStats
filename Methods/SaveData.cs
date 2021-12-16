using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Methods
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
            var newWins = 0;
            var newLosses = 0;

            if (didWin) {newWins = oldWins + 1; newTotal += 1;}
            else {newLosses = oldLosses + 1; newTotal += 1;}

            var newPoints = oldPoints + points;
            var newAssists = oldAssists + assists;
            var newSaves = oldSaves + saves;
            var newStuns = oldStuns + stuns;
            
            float winRate = (int)Math.Round((double)(100 * newWins) / newTotal);
            
            NewData(newPoints, newAssists, newSaves, newStuns, newTotal, newWins, newLosses, winRate);
        }

        public static void NewData(int points, int assists, int saves, int stuns, int total, int wins, int losses,
            float winrate)
        {
            var initialStorage = new JObject(
                new JProperty("points", points),
                new JProperty("assists", assists),
                new JProperty("saves", saves),
                new JProperty("stuns", stuns),
                new JProperty("wins", wins),
                new JProperty("losses", losses),
                new JProperty("total", total),
                new JProperty("winrate", winrate),
                new JProperty("hasRunBefore", true));

            const string path = "C:\\Users\\Public\\Documents\\EchoStatsLogger\\savedData.json";
            File.Delete(path);
            if (File.Exists(path)) Console.WriteLine("File Already Exists");
            else
            {
                using (StreamWriter file = File.CreateText(path))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    initialStorage.WriteTo(writer);
                }
            }
            RoundListener.GameStatus();
        }
        
    }
    
}