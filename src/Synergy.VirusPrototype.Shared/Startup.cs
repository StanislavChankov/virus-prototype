using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Xna.Framework;
using Synergy.VirusPrototype.Shared.Extensions;
using Synergy.VirusPrototype.Shared.Infrastructure;
using Synergy.VirusPrototype.Shared.Navigation;
using Synergy.VirusPrototype.Shared.Navigation.Abstract;
using Synergy.VirusPrototype.Shared.Registrars;

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

			services.AddTransient<Game, GameStartup>();
			services.AddTransient<ISceneNavigator, SceneNavigator>();
		}
	}
}
