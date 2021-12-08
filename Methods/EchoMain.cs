using System;

namespace Methods
{
    public static class Echo
    {
        public static void InitialRun()
        {
            
            CreateStorage.CreateFile();
            HasRunBefore.RunBefore();
            Console.Write(HasRunBefore.RunBefore());
            HasRunBefore.TestRunBefore(HasRunBefore.RunBefore());
            // PlayerLocation.FindPlayer();
            // RoundListener.GameStatus();
        }
    }
}