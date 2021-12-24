using System;

namespace EchoStatsWeb.Methods
{
    public static class Echo
    {
        public static void InitialRun()
        {

            CreateStorage.CreateFile();
            HasRunBefore.TestRunBefore(HasRunBefore.RunBefore());
            // PlayerLocation.FindPlayer();
            // RoundListener.GameStatus();
       
        }
    }
}