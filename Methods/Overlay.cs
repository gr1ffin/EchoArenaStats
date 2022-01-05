using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace EchoStats.Methods
{
    public static class Overlay
    {
        public static async Task WriteToOverlay(int t, int w, int l, float wr)
        {
            string[] overlay =
            {
                "Total Games: " + t, "Wins: " + w, "Losses: " + l, "Win Rate: " + wr
            };
            await File.WriteAllLinesAsync(Echo.HomePath + "Overlay.txt", overlay);
        }

        public static async Task WriteToPersonal(int p, int a, int s, int st, int ppg, int apg, int spg, int stpg, int t, int w, int l, float wr)
        {
            string[] personalStats =
            {
                "Points: " + p, "Assists: " + a, "Saves: " + s, "Stuns: " + st, "\n",
                "Points Per Game" + ppg, "Assists Per Game: " + apg, "Saves Per Game:" + spg, "Stuns Per Game: " + stpg, "\n", 
                "Total Games: " + t, "Wins: " + w, "Losses: " + l, "Win Rate: " + wr
            };
            await File.WriteAllLinesAsync(Echo.HomePath + "Stats.txt", personalStats);
        }
    }
}