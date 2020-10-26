using Microsoft.Xna.Framework.Graphics;

namespace Synergy.VirusPrototype.Core.Builders.Abstract
{
	public interface IBuilder<out TView>
		where TView : IView
	{
		TView Build(Texture2D pixel);
	}
}
