using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetCore.AutoRegisterDi;
using Serilog;
using Serilog.Extensions.Logging;
using Synergy.VirusPrototype.Domain.Models.Nomenclatures;
using Synergy.VirusPrototype.Shared.Options;
using Synergy.VirusPrototype.Shared.Services.Abstract;

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

		public static void AddLogger(this IServiceCollection services, IConfiguration configuration)
		{
			using var logger = new LoggerConfiguration().ReadFrom
												  .Configuration(configuration)
												  .CreateLogger();

			Log.Logger = logger;

			using var loggerProvider = new SerilogLoggerProvider(logger);

			services.AddLogging(x => x.ClearProviders());
			services.AddSingleton<ILoggerProvider>(loggerProvider);
		}

		/// <summary>
		/// Create service provider that resolve objects.
		/// </summary>
		/// <param name="services">The service collection.</param>
		public static void AddServices(this IServiceCollection services)
		{
			services.RegisterAssemblyPublicNonGenericClasses(
				typeof(IRectangleDrawer).Assembly)
			.Where(c => c.GetInterfaces().Contains(typeof(IService)))
			.AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
		}
	}
}
