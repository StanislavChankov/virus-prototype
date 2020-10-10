using Microsoft.Extensions.DependencyInjection;
using Synergy.VirusPrototype.Shared.Options;
using Synergy.VirusPrototype.Shared.Pages.Enums;

namespace Synergy.VirusPrototype.Shared.Registrars
{
	public static class OptionsRegistrar
	{
		public static void RegisterOptions(this IServiceCollection services)
		{
			services.Configure<PageOptions>(opt =>
			{
				opt.StartupPageType = PageType.Menu;
			});
		}
	}
}
