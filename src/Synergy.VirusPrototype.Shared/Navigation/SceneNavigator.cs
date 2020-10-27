using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Options;
using Synergy.VirusPrototype.Shared.Exceptions;
using Synergy.VirusPrototype.Shared.Navigation.Abstract;
using Synergy.VirusPrototype.Shared.Options;
using Synergy.VirusPrototype.Shared.Scenes.Abstract;

namespace Synergy.VirusPrototype.Shared.Navigation
{
	public class SceneNavigator : ISceneNavigator
	{
		private readonly PageOptions _pageOptions;
		private readonly ISceneTypeSceneMappingProvider _sceneTypeSceneMappingProvider;

		public SceneNavigator(
			IMediator mediator,
			IOptions<PageOptions> pageOptions,
			ISceneTypeSceneMappingProvider sceneTypeSceneMappingProvider)
		{
			_pageOptions = pageOptions.Value;
			_sceneTypeSceneMappingProvider = sceneTypeSceneMappingProvider;
		}

		public async Task StartAsync()
		{
			if (!_sceneTypeSceneMappingProvider.SceneTypeSceneKeyValuePair.TryGetValue(_pageOptions.StartupSceneType, out Func<IScene> getSceneFunc))
			{
				throw new SceneNotImplementedException($"Scene {_pageOptions.StartupSceneType} is not implemented!");
			}

			var scene = getSceneFunc();

			await scene.NavigateAsync();
		}
	}
}
