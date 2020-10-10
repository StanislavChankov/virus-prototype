using System.Threading.Tasks;
using Synergy.VirusPrototype.Shared;

namespace Synergy.VirusPrototype.CrossPlatformDesktop
{
	public static class Program
	{
		//[STAThread]
		private static async Task Main(string[] args)
		{
			await SharedProgram.Main(args);
		}
	}
}
