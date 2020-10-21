using Microsoft.Xna.Framework;

namespace Synergy.VirusPrototype.Shared.Services.Abstract
{
	public interface ILineDrawer : IService
	{
		void DrawLine(float x1, float y1, float x2, float y2, Color color);

		void DrawLine(float x1, float y1, float x2, float y2, Color color, float thickness);

		void DrawLine(Vector2 point1, Vector2 point2, Color color);

		void DrawLine(Vector2 point1, Vector2 point2, Color color, float thickness);

		void DrawLine(Vector2 point, float length, float angle, Color color);

		void DrawLine(Vector2 point, float length, float angle, Color color, float thickness);
	}
}
