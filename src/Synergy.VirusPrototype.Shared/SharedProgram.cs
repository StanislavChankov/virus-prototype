using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Xna.Framework;
using MonoGame.Framework.Utilities;
using Serilog;
using Synergy.VirusPrototype.Resources;
using Synergy.VirusPrototype.Shared.Exceptions;

namespace Synergy.VirusPrototype.Shared
{
	public static class SharedProgram
	{
		public static Game Game { get; private set; }

		public static async Task Main(string[] args)
		{
			try
			{
				if (PlatformInfo.MonoGamePlatform == MonoGamePlatform.Android)
				{
					BuildHost(args);
				}
				else
				{
					await BuildCommonHostAsync(args);
				}
			}
			catch (GameTerminatedException ex)
			{
				Log.Fatal(ex, CodeErrors.GameTerminated);
			}
		}

		private static async Task BuildCommonHostAsync(string[] args)
		{
			await BuildHost(args).StartAsync();
		}

		private static IHost BuildHost(string[] args)
			 => Host.CreateDefaultBuilder(args)
				.ConfigureServices((builderContext, services) =>
				{
					new Startup(builderContext.HostingEnvironment).ConfigureServices(services);

					Game game = services.BuildServiceProvider().GetRequiredService<Game>();

					Game = game;
				})
				.Build();
	}
}
