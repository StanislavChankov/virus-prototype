using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Synergy.VirusPrototype.Shared.Extensions;
using Synergy.VirusPrototype.Shared.Services.Abstract;

namespace Synergy.VirusPrototype.Shared.Services
{
	public class LineDrawer : ILineDrawer
	{
		private readonly SpriteBatch _spriteBatch;

		public LineDrawer(SpriteBatch spriteBatch)
		{
			_spriteBatch = spriteBatch;
		}

		/// <summary>
		/// Draws a line from point1 to point2 with an offset
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="x1">The X coord of the first point</param>
		/// <param name="y1">The Y coord of the first point</param>
		/// <param name="x2">The X coord of the second point</param>
		/// <param name="y2">The Y coord of the second point</param>
		/// <param name="color">The color to use</param>
		public void DrawLine(float x1, float y1, float x2, float y2, Color color)
		{
			DrawLine(new Vector2(x1, y1), new Vector2(x2, y2), color, 1.0f);
		}

		/// <summary>
		/// Draws a line from point1 to point2 with an offset
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="x1">The X coord of the first point</param>
		/// <param name="y1">The Y coord of the first point</param>
		/// <param name="x2">The X coord of the second point</param>
		/// <param name="y2">The Y coord of the second point</param>
		/// <param name="color">The color to use</param>
		/// <param name="thickness">The thickness of the line</param>
		public void DrawLine(float x1, float y1, float x2, float y2, Color color, float thickness)
		{
			DrawLine(new Vector2(x1, y1), new Vector2(x2, y2), color, thickness);
		}

		/// <summary>
		/// Draws a line from point1 to point2 with an offset
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="point1">The first point</param>
		/// <param name="point2">The second point</param>
		/// <param name="color">The color to use</param>
		public void DrawLine(Vector2 point1, Vector2 point2, Color color)
		{
			DrawLine(point1, point2, color, 1.0f);
		}

		/// <summary>
		/// Draws a line from point1 to point2 with an offset
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="point1">The first point</param>
		/// <param name="point2">The second point</param>
		/// <param name="color">The color to use</param>
		/// <param name="thickness">The thickness of the line</param>
		public void DrawLine(Vector2 point1, Vector2 point2, Color color, float thickness)
		{
			// calculate the distance between the two vectors
			float distance = Vector2.Distance(point1, point2);

			// calculate the angle between the two vectors
			float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);

			DrawLine(point1, distance, angle, color, thickness);
		}

		/// <summary>
		/// Draws a line from point1 to point2 with an offset
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="point">The starting point</param>
		/// <param name="length">The length of the line</param>
		/// <param name="angle">The angle of this line from the starting point in radians</param>
		/// <param name="color">The color to use</param>
		public void DrawLine(Vector2 point, float length, float angle, Color color)
		{
			DrawLine(point, length, angle, color, 1.0f);
		}

		/// <summary>
		/// Draws a line from point1 to point2 with an offset
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="point">The starting point</param>
		/// <param name="length">The length of the line</param>
		/// <param name="angle">The angle of this line from the starting point</param>
		/// <param name="color">The color to use</param>
		/// <param name="thickness">The thickness of the line</param>
		public void DrawLine(Vector2 point, float length, float angle, Color color, float thickness)
		{
			using var pixel = _spriteBatch.GetPixel();

			// stretch the pixel between the two vectors
			_spriteBatch.Draw(pixel,
							 point,
							 null,
							 color,
							 angle,
							 Vector2.Zero,
							 new Vector2(length, thickness),
							 SpriteEffects.None,
							 0);
		}
	}
}
