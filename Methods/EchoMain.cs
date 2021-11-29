namespace EchoArenaStats.Methods
{
    public class EchoMain
    {
        public static void Main()
        {
            CreateServer.StartServer();
            PlayerLocation.FindPlayer();
        }
    }
}