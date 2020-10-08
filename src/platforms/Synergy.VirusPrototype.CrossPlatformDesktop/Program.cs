using Synergy.VirusPrototype.Shared;

namespace Synergy.VirusPrototype.CrossPlatformDesktop
{
    public static class Program
    {
        //[STAThread]
        static void Main()
        {
            using (var game = new VirusPrototypeGame())
            {
                game.Run();
            }
        }
    }
}
