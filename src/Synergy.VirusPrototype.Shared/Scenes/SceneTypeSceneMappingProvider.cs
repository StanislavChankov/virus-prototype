using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Synergy.VirusPrototype.Domain.Models.Nomenclatures;
using Synergy.VirusPrototype.Shared.Scenes.Abstract;

namespace Synergy.VirusPrototype.Shared.Scenes
{
	public class SceneTypeSceneMappingProvider : ISceneTypeSceneMappingProvider
	{
		private readonly IServiceProvider _serviceProvider;

		public SceneTypeSceneMappingProvider(IServiceProvider serviceProvider)
		{
			SceneTypeSceneKeyValuePair = new Dictionary<SceneType, Func<IScene>>
			{
				{ SceneType.Menu, GetScene<IMenuScene> },
				{ SceneType.Game, GetScene<IGameScene> },
			};
			_serviceProvider = serviceProvider;
		}

		public IDictionary<SceneType, Func<IScene>> SceneTypeSceneKeyValuePair { get; }

		public IScene GetScene<TScene>()
			where TScene : IScene
				=> _serviceProvider.GetRequiredService<TScene>();
	}
}
