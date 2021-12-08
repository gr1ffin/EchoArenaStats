using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Methods
{
    public static class HasRunBefore
    {

        public static bool RunBefore()
        {
            var baseData = File.ReadAllText("C:\\Users\\Public\\Documents\\EchoStatsLogger\\savedData.json");
            dynamic data = JsonConvert.DeserializeObject(baseData);
            System.Threading.Thread.Sleep(500);
            bool runCheck = JsonConvert.SerializeObject(data?["hasRunBefore"]) != "false";
            return runCheck;
        }

        public static void TestRunBefore(bool checkStatus)
        {
            if (!checkStatus)
            {

                var settingsFile = new JObject(
                    new JProperty("IP", "127.0.0.1"),
                    new JProperty("Username", "Username Here"));
                const string path = "C:\\Users\\Public\\Documents\\EchoStatsLogger\\settings.json";
                if (File.Exists(path)) Console.WriteLine("File Already Exists");
                else
                {
                    using var file = File.CreateText(path);
                    using var writer = new JsonTextWriter(file);
                    settingsFile.WriteTo(writer);
                }
            }
        }
    }
}