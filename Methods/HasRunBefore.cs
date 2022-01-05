using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EchoStats.Methods
{
    public static class HasRunBefore
    {

        public static bool RunBefore()
        {
            var baseData = File.ReadAllText(Echo.DataPath);
            dynamic data = JsonConvert.DeserializeObject(baseData);
            Thread.Sleep(500);
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
                if (File.Exists(Echo.SettingsPath))
                {/* */}
                else
                {
                    using var file = File.CreateText(Echo.SettingsPath);
                    using var writer = new JsonTextWriter(file);
                    settingsFile.WriteTo(writer);
                }
            }
        }
    }
}