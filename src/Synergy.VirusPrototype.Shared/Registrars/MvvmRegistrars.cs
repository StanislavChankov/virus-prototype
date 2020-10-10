using Microsoft.Extensions.DependencyInjection;
using Synergy.VirusPrototype.Shared.Pages.Menu;

namespace Synergy.VirusPrototype.Shared.Registrars
{
	public static class MvvmRegistrars
	{
		public static void RegisterMvvm(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<MenuView>();
			serviceCollection.AddTransient<MenuUpdater>();
		}
	}
}
