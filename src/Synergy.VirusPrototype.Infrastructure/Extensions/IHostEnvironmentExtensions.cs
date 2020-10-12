using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Synergy.VirusPrototype.Infrastructure.Extensions
{
	public static class IHostEnvironmentExtensions
    {
		public static IConfiguration BuildConfiguration(this IHostEnvironment environment, string rootDirectory)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(rootDirectory)
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables()
				.Build();

			return configuration;
		}
	}
}
