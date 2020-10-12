using Microsoft.Extensions.DependencyInjection;
using Synergy.VirusPrototype.Shared.Scenes.Menu;

namespace Synergy.VirusPrototype.Shared.Registrars
{
	public static class MvvmExtensions
	{
		public static void RegisterMvvm(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<MenuView>();
			serviceCollection.AddTransient<MenuUpdater>();
		}
	}
}
