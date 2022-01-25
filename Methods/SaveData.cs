using System;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EchoStats.Methods
{

    public static class SaveData
    {
        public static void SaveStats(int points, int assists, int saves, int stuns, bool didWin)
        {
            var baseData = File.ReadAllText(Echo.DataPath);
            dynamic data = JsonConvert.DeserializeObject(baseData);
            Thread.Sleep(500);

            var oldPoints = Int32.Parse(JsonConvert.SerializeObject(data?["points"]));
            var oldAssists = Int32.Parse(JsonConvert.SerializeObject(data?["saves"]));
            var oldSaves = Int32.Parse(JsonConvert.SerializeObject(data?["stuns"]));
            var oldStuns = Int32.Parse(JsonConvert.SerializeObject(data?["assists"]));
            // Separate 
            var oldTotal = Int32.Parse(JsonConvert.SerializeObject(data?["total"]));
            var oldWinrate = JsonConvert.SerializeObject(data?["winrate"]);
            var oldLosses = Int32.Parse(JsonConvert.SerializeObject(data?["losses"]));
            var oldWins = Int32.Parse(JsonConvert.SerializeObject(data?["wins"]));

            var newTotal = oldTotal;
            var newWins = 0;
            var newLosses = 0;

            if (didWin) { newWins = oldWins + 1; newTotal += 1; }
            else { newLosses = oldLosses + 1; newTotal += 1; }

            var newPoints = oldPoints + points;
            var newAssists = oldAssists + assists;
            var newSaves = oldSaves + saves;
            var newStuns = oldStuns + stuns;

            float winRate = (int)Math.Round((double)(100 * newWins) / newTotal);

            

            NewData(newPoints, newAssists, newSaves, newStuns, newTotal, newWins, newLosses, winRate, didWin, winstreak(didWin));
            
            
        }

        private static void NewData(int points, int assists, int saves, int stuns, int total, int wins, int losses,
            float winrate, bool didWin, int winstreak)
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
                new JProperty("winstreak"),
                new JProperty("hasRunBefore", true));

            File.Delete(Echo.DataPath);
            if (File.Exists(Echo.DataPath)) Console.WriteLine("File Already Exists");
            else
            {
                using StreamWriter file = File.CreateText(Echo.DataPath);
                using JsonTextWriter writer = new JsonTextWriter(file);
                initialStorage.WriteTo(writer);
            }
#pragma warning disable 4014
            Overlay.WriteToOverlay(total, wins, losses, winrate);
#pragma warning restore 4014
            //DailyStats.WhichOutput(points, assists, saves, stuns, total, wins, losses, winrate, didWin);
            AverageStats(points, assists, saves, stuns, total, wins, losses, winrate);
            Thread.Sleep(120000);
            RoundListener.GameStatus();
        }

        private static void AverageStats(int points, int assists, int saves, int stuns, int total, int wins, int losses, float winrate)
        {
            var ppg = points / total;
            var apg = assists / total;
            var spg = saves / total;
            var stpg = stuns / total;
#pragma warning disable 4014
            Overlay.WriteToPersonal(points, assists, saves, stuns, ppg, apg, spg, stpg, total, wins, losses, winrate );
#pragma warning restore 4014
        }

        private static dynamic winstreak(bool didWin)
        {
            if (didWin)
            {
                var baseData = File.ReadAllText(Echo.DataPath);
                dynamic data = JsonConvert.DeserializeObject(baseData);
                Thread.Sleep(500);

                var oldWinStreak = Int32.Parse(JsonConvert.SerializeObject(data?["winstreak"]));
                var winstreak = oldWinStreak + 1;
                return winstreak;
            }
            else
            {
                var winstreak = 0;
                return winstreak;
            }
        }

    }

}