using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Synergy.VirusPrototype.Shared.Extensions
{
	public static class MediatRExtensions
	{
		public static void RegisterMediatRServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<IMediator, Mediator>();

			serviceCollection.AddMediatR(typeof(MediatRExtensions).Assembly);

			// Register MediatR implementations of Command and Handler.
		}
	}
}
