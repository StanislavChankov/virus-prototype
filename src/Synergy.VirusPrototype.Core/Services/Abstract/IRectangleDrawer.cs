using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Synergy.VirusPrototype.Core.Models;

namespace Synergy.VirusPrototype.Shared.Services.Abstract
{
	public interface IRectangleDrawer : IService
	{
		void DrawRectangle(Texture2D texture, Rectangle rect, Color color);

		void DrawRectangle(Texture2D texture, Rectangle rect, Color color, float thickness);

		void DrawRectangle(Texture2D texture, Vector2 location, Vector2 size, Color color);

		void DrawRectangle(Texture2D texture, Vector2 location, Vector2 size, Color color, float thickness);

		void DrawRectangle(Texture2D texture, Rectangle2D rectangle2D);
	}
}
