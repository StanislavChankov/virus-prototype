using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Synergy.VirusPrototype.Core.Models;

namespace Synergy.VirusPrototype.Shared.Services.Abstract
{
	public interface ILineDrawer : IService
	{
		void DrawLine(Texture2D texture, float x1, float y1, float x2, float y2, Color color);

		void DrawLine(Texture2D texture, float x1, float y1, float x2, float y2, Color color, float thickness);

		void DrawLine(Texture2D texture, Vector2 point1, Vector2 point2, Color color);

		void DrawLine(Texture2D texture, Vector2 point1, Vector2 point2, Color color, float thickness);

		void DrawLine(Texture2D texture, Vector2 point, float length, float angle, Color color);

		void DrawLine(Texture2D texture, Vector2 point, float length, float angle, Color color, float thickness);

		void DrawLine(Texture2D texture, Line2D line);
	}
}
