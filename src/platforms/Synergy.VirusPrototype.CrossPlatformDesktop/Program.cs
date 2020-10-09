using Synergy.VirusPrototype.Shared;

namespace Synergy.VirusPrototype.CrossPlatformDesktop
{
	public static class Program
	{
		//[STAThread]
		private static void Main()
		{
			using (var game = new VirusPrototypeGame())
			{
				game.Run();
			}
		}
	}
}
