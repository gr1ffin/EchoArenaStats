using System;
using System.IO;
using System.Net;

namespace EchoStatsWeb.Methods
{
    public static class GetUrlC
    {
        public static string GetUrl(string url)
        {
            var wrGetUrl = WebRequest.Create(url);
            var objStream = wrGetUrl.GetResponse().GetResponseStream();
            var objReader = new StreamReader(objStream ?? throw new InvalidOperationException());
            //System.Threading.Thread.Sleep(5000);
            var baseData = objReader.ReadToEnd();
            //Console.WriteLine(baseData); WHOLE DATA AS STRING.
            return baseData;
        }

    }
}