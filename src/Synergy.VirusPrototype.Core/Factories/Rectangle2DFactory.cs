using Microsoft.Xna.Framework;
using Synergy.VirusPrototype.Core.Models;

namespace Synergy.VirusPrototype.Core.Factories
{
	public static class Rectangle2DFactory
	{
		/// <summary>
		/// Gets a rectangle with the thickness provided
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="rect">The rectangle to draw</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public static Rectangle2D GetRectangle(Rectangle rect, Color color)
		{
			return GetRectangle(rect, color, 1.0f);
		}

		/// <summary>
		/// Gets a rectangle with the thickness provided
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="location">Where to draw</param>
		/// <param name="size">The size of the rectangle</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public static Rectangle2D GetRectangle(Vector2 location, Vector2 size, Color color)
		{
			return GetRectangle(new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y), color, 1.0f);
		}

		/// <summary>
		/// Gets a rectangle with the thickness provided
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="location">Where to draw</param>
		/// <param name="size">The size of the rectangle</param>
		/// <param name="color">The color to draw the rectangle in</param>
		/// <param name="thickness">The thickness of the line</param>
		public static Rectangle2D GetRectangle(Vector2 location, Vector2 size, Color color, float thickness)
		{
			return GetRectangle(new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y), color, thickness);
		}

		public static Rectangle2D GetRectangle(Rectangle rect, Color color, float thickness)
		{
			return new Rectangle2D
			{
				TopLine = Line2DFactory.GetLine(new Vector2(rect.X, rect.Y), new Vector2(rect.Right, rect.Y), color, thickness),
				LeftLine = Line2DFactory.GetLine(new Vector2(rect.X + 1f, rect.Y), new Vector2(rect.X + 1f, rect.Bottom + thickness), color, thickness),
				BottomLine = Line2DFactory.GetLine(new Vector2(rect.X, rect.Bottom), new Vector2(rect.Right, rect.Bottom), color, thickness),
				RightLine = Line2DFactory.GetLine(new Vector2(rect.Right + 1f, rect.Y), new Vector2(rect.Right + 1f, rect.Bottom + thickness), color, thickness),
			};
		}
	}
}
