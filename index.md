This is an example code block that shows the API listener. 
```csharp
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
                }
                else
                {
                    Console.WriteLine(JsonConvert.SerializeObject(data2?["game_status"]));
                    Thread.Sleep(5000);
                }



            }
            ```
