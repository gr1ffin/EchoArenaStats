using System;

namespace EchoArenaStats.Methods
{
    public static class EchoMain
    {
        public static void Main()
        {
            
            CreateStorage.CreateFile();
            HasRunBefore.RunBefore();
            Console.Write(HasRunBefore.RunBefore());
            HasRunBefore.TestRunBefore(HasRunBefore.RunBefore());
            // CreateServer.StartServer();
            // PlayerLocation.FindPlayer();
            // RoundListener.GameStatus();
        }
    }
}