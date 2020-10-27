using Microsoft.Xna.Framework.Graphics;
using Synergy.VirusPrototype.Core.Controls.Abstract;

namespace Synergy.VirusPrototype.Core.Builders.Abstract
{
	public interface IBuilder<out TView>
		where TView : IView
	{
		TView Build(Texture2D pixel);
	}
}
