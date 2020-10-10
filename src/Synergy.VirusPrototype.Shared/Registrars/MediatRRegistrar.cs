using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Synergy.VirusPrototype.Shared.Registrars
{
	public static class MediatRRegistrar
	{
		public static void RegisterMediatRServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<IMediator, Mediator>();

			serviceCollection.AddMediatR(typeof(MediatRRegistrar).Assembly);

			// Register MediatR implementations of Command and Handler.
		}
	}
}
