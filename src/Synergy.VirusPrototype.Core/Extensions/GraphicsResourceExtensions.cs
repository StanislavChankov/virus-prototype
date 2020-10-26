using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Synergy.VirusPrototype.Shared.Extensions
{
	public static class GraphicsResourceExtensions
	{
		public static Texture2D GetPixel(this GraphicsResource graphicsResource)
		{
			var pixel = new Texture2D(graphicsResource.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);

			pixel.SetData(new[] { Color.White });

			return pixel;
		}
	}
}
