using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Synergy.VirusPrototype.Shared.Infrastructure
{
	public class CurrentHostEnvironment : IHostEnvironment
	{
		public string EnvironmentName { get; set; }

		public string ApplicationName { get; set; }

		public string ContentRootPath { get; set; }

		public IFileProvider ContentRootFileProvider { get; set; }
	}
}
