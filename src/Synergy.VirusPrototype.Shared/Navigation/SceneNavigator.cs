using System.Threading.Tasks;
using MediatR;
using Synergy.VirusPrototype.Shared.Navigation.Abstract;

namespace Synergy.VirusPrototype.Shared.Navigation
{
	public class SceneNavigator : ISceneNavigator
	{
		private readonly IMediator _mediator;

		public SceneNavigator(IMediator mediator)
		{
			_mediator = mediator;
		}

		public Task StartAsync()
		{
			return Task.CompletedTask;
		}
	}
}
