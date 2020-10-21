using Microsoft.Xna.Framework;

namespace Synergy.VirusPrototype.Shared.Services.Abstract
{
	public interface IFilledRectangleDrawer : IService
	{
		void FillRectangle(Rectangle rect, Color color);

		void FillRectangle(Rectangle rect, Color color, float angle);

		void FillRectangle(Vector2 location, Vector2 size, Color color);

		void FillRectangle(Vector2 location, Vector2 size, Color color, float angle);

		void FillRectangle(float x, float y, float w, float h, Color color);

		void FillRectangle(float x, float y, float w, float h, Color color, float angle);
	}
}
