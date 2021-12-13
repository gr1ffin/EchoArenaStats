using System;

namespace Methods
{
    public static class Echo
    {
        public static void InitialRun()
        {
            
            CreateStorage.CreateFile();
            //HasRunBefore.RunBefore();
            HasRunBefore.TestRunBefore(HasRunBefore.RunBefore());
            // PlayerLocation.FindPlayer();
            // RoundListener.GameStatus();
        }
    }
}