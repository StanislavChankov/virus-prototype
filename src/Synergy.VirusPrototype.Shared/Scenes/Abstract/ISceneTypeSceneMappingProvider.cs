using System;
using System.Collections.Generic;
using Synergy.VirusPrototype.Domain.Models.Nomenclatures;

namespace Synergy.VirusPrototype.Shared.Scenes.Abstract
{
	public interface ISceneTypeSceneMappingProvider
	{
		IDictionary<SceneType, Func<IScene>> SceneTypeSceneKeyValuePair { get; }

		IScene GetScene<TScene>()
			where TScene : IScene;
	}
}
