namespace EchoArenaStats.Methods
{
    public static class EchoMain
    {
        public static void Main()
        {
            CreateStorage.CreateFile();
            CreateServer.StartServer();
            PlayerLocation.FindPlayer();
            RoundListener.GameStatus();
        }
    }
}