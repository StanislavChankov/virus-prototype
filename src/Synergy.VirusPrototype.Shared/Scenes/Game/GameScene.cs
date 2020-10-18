using System.Threading.Tasks;
using Synergy.VirusPrototype.Shared.Scenes.Abstract;

namespace Synergy.VirusPrototype.Shared.Scenes.Game
{
	public class GameScene : IGameScene
	{
		public Task NavigateAsync() => Task.CompletedTask;
	}
}
