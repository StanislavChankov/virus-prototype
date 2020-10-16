using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MonoGame.Framework.Utilities;
using Synergy.VirusPrototype.Infrastructure.Extensions;

namespace Synergy.VirusPrototype.Shared.Infrastructure
{
	public static class IHostEnvironmentExtensions
	{
		private const string CurrentAssemblyName = "Synergy.VirusPrototype.Shared";

		public static IConfiguration BuildConfiguration(this IHostEnvironment environment)
		{
			IConfiguration configuration;

			if (PlatformInfo.MonoGamePlatform == MonoGamePlatform.Android)
			{
				configuration = BuildAndroidConfiguration();
			}
			else
			{
				string currentProject = GetAssemblyDirectory(CurrentAssemblyName);

				configuration = environment.BuildConfiguration(currentProject);
			}

			return configuration;
		}

		private static IConfiguration BuildAndroidConfiguration()
		{
			Assembly? currentAssembly = IntrospectionExtensions.GetTypeInfo(typeof(Startup)).Assembly;

			Stream jsonStream = currentAssembly.GetManifestResourceStream($"{CurrentAssemblyName}.appsettings.json");

			using StreamReader? reader = new StreamReader(jsonStream);

			string json = reader.ReadToEnd();

			using MemoryStream? stream = new MemoryStream(Encoding.ASCII.GetBytes(json));

			IConfigurationRoot? configuration = new ConfigurationBuilder()
				.AddJsonStream(stream)
				.Build();

			return configuration;
		}

		private static string GetAssemblyDirectory(string assemblyName)
		{
			string codeBase = Assembly.Load(assemblyName).CodeBase;

			UriBuilder? uri = new UriBuilder(new Uri(codeBase));

			string path = Uri.UnescapeDataString(uri.Path);

			return Path.GetDirectoryName(path);
		}
	}
}
