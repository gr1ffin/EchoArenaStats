using System;
using System.Reflection;

namespace EchoStats.Methods
{
    public static class Echo
    {
        public static readonly string HomePath = "..\\..\\..\\Storage\\";
        public static readonly string DataPath =  HomePath + "savedData.json";
        public static readonly string SettingsPath = HomePath + "settings.json";
        public static void Main(String[] args)
        {
            PlayerInfo.DisplayPlayerInfo();
            CreateStorage.CreateFile();
            HasRunBefore.TestRunBefore(HasRunBefore.RunBefore());
            RoundListener.GameStatus();
       
        }
    }
}