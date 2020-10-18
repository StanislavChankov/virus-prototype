using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Synergy.VirusPrototype.Shared.Extensions;
using Synergy.VirusPrototype.Shared.Infrastructure;
using Synergy.VirusPrototype.Shared.Navigation;
using Synergy.VirusPrototype.Shared.Navigation.Abstract;
using Synergy.VirusPrototype.Shared.Registrars;
using Synergy.VirusPrototype.Shared.Scenes;
using Synergy.VirusPrototype.Shared.Scenes.Abstract;
using Synergy.VirusPrototype.Shared.Scenes.Game;
using Synergy.VirusPrototype.Shared.Scenes.Menu;

namespace Synergy.VirusPrototype.Shared
{
	public class Startup
	{
		public Startup(IHostEnvironment hostEnvironment)
		{
			HostEnvironment = hostEnvironment;

			Configuration = hostEnvironment.BuildConfiguration();
		}

		protected IConfiguration Configuration { get; }

		protected IHostEnvironment HostEnvironment { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.RegisterMediatRServices();
			services.RegisterMvvm();
			services.RegisterOptions();

			services.AddSingleton<Game, GameStartup>();

			services.AddScoped<SpriteBatch>(provider => new SpriteBatch(((GameStartup)provider.GetRequiredService<Game>()).GraphicsDevice));
			services.AddScoped<ContentManager>(provider => provider.GetRequiredService<Game>().Content);
			services.AddScoped<GraphicsDevice>(provider => provider.GetRequiredService<Game>().GraphicsDevice);

			// Scenes
			services.AddScoped<ISceneNavigator, SceneNavigator>();
			services.AddScoped<ISceneTypeSceneMappingProvider, SceneTypeSceneMappingProvider>();
			services.AddScoped<IGameScene, GameScene>();
			services.AddScoped<IMenuScene, MenuScene>();
		}
	}
}
