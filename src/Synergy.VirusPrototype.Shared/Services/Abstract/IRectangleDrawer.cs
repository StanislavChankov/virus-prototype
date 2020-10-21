using Microsoft.Xna.Framework;

namespace Synergy.VirusPrototype.Shared.Services.Abstract
{
	public interface IRectangleDrawer : IService
	{
		void DrawRectangle(Rectangle rect, Color color);

		void DrawRectangle(Rectangle rect, Color color, float thickness);

		void DrawRectangle(Vector2 location, Vector2 size, Color color);

		void DrawRectangle(Vector2 location, Vector2 size, Color color, float thickness);
	}
}
