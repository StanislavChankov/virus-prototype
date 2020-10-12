using Microsoft.Extensions.DependencyInjection;
using Synergy.VirusPrototype.Shared.Options;
using Synergy.VirusPrototype.Shared.Scenes.Enums;

namespace Synergy.VirusPrototype.Shared.Registrars
{
	public static class ServiceCollectionExtensions
	{
		public static void RegisterOptions(this IServiceCollection services)
		{
			services.Configure<PageOptions>(opt =>
			{
				opt.StartupSceneType = SceneType.Menu;
			});
		}
	}
}
