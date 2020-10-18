using Microsoft.Extensions.DependencyInjection;
using Synergy.VirusPrototype.Domain.Models.Nomenclatures;
using Synergy.VirusPrototype.Shared.Options;

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
