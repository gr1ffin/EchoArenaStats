namespace EchoArenaStats.Methods
{
    public class EchoMain
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