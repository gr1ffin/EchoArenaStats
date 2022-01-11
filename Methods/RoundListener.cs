using System;
using System.Collections;
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
        public static ArrayList GoalThrow = new ArrayList();
        public static void GameStatus()
        {

            var settingsData = File.ReadAllText(Echo.SettingsPath);
            dynamic dataB = JsonConvert.DeserializeObject(settingsData);
            string ip = Convert.ToString(JsonConvert.SerializeObject(dataB?["IP"]));
            string parsedIp = ip.Substring(1, ip.Length - 2);
            

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
                if (JsonConvert.SerializeObject(data?["game_status"]) != JsonConvert.SerializeObject(data2?["game_status"]))
                {
                    if (takeData.Substring(1, takeData.Length - 2) == "goal")
                    {
                        var lastPlayerToScore = JsonConvert.SerializeObject(data2?["last_score"]["person_scored"]);
                        if (lastPlayerToScore == PlayerInfo.User)
                        {
                            var goalSpeed = JsonConvert.SerializeObject(data2?["last_score"]["disc_speed"]);
                            var distanceScored = JsonConvert.SerializeObject(data2?["last_score"]["distance_thrown"]);
                            var goalType = JsonConvert.SerializeObject(data2?["last_score"]["goal_type"]);
                            Console.WriteLine(PlayerInfo.User + "scored a " + goalType + "from " + distanceScored + "at " + goalSpeed + "m/s!");
                            var totalSpeed = JsonConvert.SerializeObject(data?["last_throw"]["total_speed"]);
                            var armSpeed = JsonConvert.SerializeObject(data?["last_throw"]["speed_from_arm"]);
                            var wristSpeed = JsonConvert.SerializeObject(data?["last_throw"]["speed_from_wrist"]);
                            var movementSpeed = JsonConvert.SerializeObject(data?["last_throw"]["speed_from_movement"]);
                            Console.WriteLine("Throw Information");
                            Console.WriteLine("Total Speed: " + totalSpeed);
                            Console.WriteLine("Arm Speed: " + armSpeed);
                            Console.WriteLine("Wrist Speed; " + wristSpeed);
                            Console.WriteLine("Movement Speed: " + movementSpeed);
                            GoalThrow.Add(totalSpeed);
                        }
                    }

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