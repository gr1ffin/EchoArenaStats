using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EchoStats.Methods
{
    public static class DailyStats
    {
        private static Boolean CheckDay()
        {
            var baseData = File.ReadAllText(Echo.DataPath);
            dynamic data = JsonConvert.DeserializeObject(baseData);
            var dataDate = JsonConvert.SerializeObject(data?["date"]);
            var currentDate = DateTime.Today.ToString("d");

            bool sameDate = (currentDate == dataDate);
            return sameDate;
        }

        private static void OverrideDaily(int points, int assists, int saves, int stuns, bool didWin)
        {
            var wins = 0;
            var losses = 0;
            var total = 0;
            if (didWin) {wins+= 1;}else {losses += 1;}
            float winRate = (int)Math.Round((double)(100 * wins) / total);
            
            if(didWin) {}
            var dailyStorage = new JObject(
                new JProperty("points", points),
                new JProperty("assists", assists),
                new JProperty("saves", saves),
                new JProperty("stuns", stuns),
                new JProperty("wins", wins),
                new JProperty("losses", losses),
                new JProperty("total", total),
                new JProperty("winrate", winRate));


            if (File.Exists(Echo.HomePath + "dailyData.json")) Console.WriteLine("Daily Data file already exists.");
            else
            {
                using StreamWriter file = File.CreateText(Echo.HomePath + "dailyData.json");
                using JsonTextWriter writer = new JsonTextWriter(file);
                dailyStorage.WriteTo(writer);
            }
        }

        private static void ContinueDaily(int points, int assists, int saves, int stuns, bool didWin)
        {
            var baseData = File.ReadAllText(Echo.HomePath + "dailyData.json");
            dynamic data = JsonConvert.DeserializeObject(baseData);
            Thread.Sleep(500);

            var newPoints = JsonConvert.SerializeObject(data?["points"]) + points;
            var newAssists = JsonConvert.SerializeObject(data?["saves"]) + assists;
            var newSaves = JsonConvert.SerializeObject(data?["stuns"]) + saves;
            var newStuns = JsonConvert.SerializeObject(data?["assists"]) + stuns;

            var newTotal = JsonConvert.SerializeObject(data?["total"]) + 1;
            var newWins =  JsonConvert.SerializeObject(data?["wins"]);
            var newLosses = JsonConvert.SerializeObject(data?["losses"]);
            if (didWin) {newWins += 1;}
            else {newLosses += 1;}

            float winRate = (int)Math.Round((double)(100 * newWins) / newTotal);
            
            
            var dailyStorage = new JObject(
                new JProperty("points", newPoints),
                new JProperty("assists", newAssists),
                new JProperty("saves", newSaves),
                new JProperty("stuns", newStuns),
                new JProperty("wins", newWins),
                new JProperty("losses", newLosses),
                new JProperty("total", newTotal),
                new JProperty("winrate", winRate));


            if (File.Exists(Echo.HomePath + "dailyData.json")) Console.WriteLine("Daily Data file already exists.");
            else
            {
                using StreamWriter file = File.CreateText(Echo.HomePath + "dailyData.json");
                using JsonTextWriter writer = new JsonTextWriter(file);
                dailyStorage.WriteTo(writer);
            }
        }

        public static void WhichOutput(int points, int assists, int saves, int stuns, int total, int wins, int losses, float winrate, bool didWin)
        {
            if(CheckDay()) {ContinueDaily(points, assists, saves, stuns, total, wins, losses, winrate, didWin);}
            else {OverrideDaily(points, assists, saves, stuns, didWin);}
        }

        private static void ContinueDaily(int points, int assists, int saves, int stuns, int didWin, int wins, int losses, float winrate, bool b)
        {
            throw new NotImplementedException();
        }
    }
}