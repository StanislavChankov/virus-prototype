using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Synergy.VirusPrototype.Core.Models;
using Synergy.VirusPrototype.Shared.Services.Abstract;

namespace Synergy.VirusPrototype.Shared.Services
{
	public class RectangleDrawer : IRectangleDrawer
	{
		private readonly ILineDrawer _lineDrawer;

		public RectangleDrawer(ILineDrawer lineDrawer)
		{
			_lineDrawer = lineDrawer;
		}

		/// <summary>
		/// Draws a rectangle with the thickness provided
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="rect">The rectangle to draw</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public void DrawRectangle(Texture2D texture, Rectangle rect, Color color)
		{
			DrawRectangle(texture, rect, color, 1.0f);
		}

		/// <summary>
		/// Draws a rectangle with the thickness provided
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="rect">The rectangle to draw</param>
		/// <param name="color">The color to draw the rectangle in</param>
		/// <param name="thickness">The thickness of the lines</param>
		public void DrawRectangle(Texture2D texture, Rectangle rect, Color color, float thickness)
		{
			// TODO: Handle rotations
			// TODO: Figure out the pattern for the offsets required and then handle it in the line instead of here

			_lineDrawer.DrawLine(texture, new Vector2(rect.X, rect.Y), new Vector2(rect.Right, rect.Y), color, thickness); // top
			_lineDrawer.DrawLine(texture, new Vector2(rect.X + 1f, rect.Y), new Vector2(rect.X + 1f, rect.Bottom + thickness), color, thickness); // left
			_lineDrawer.DrawLine(texture, new Vector2(rect.X, rect.Bottom), new Vector2(rect.Right, rect.Bottom), color, thickness); // bottom
			_lineDrawer.DrawLine(texture, new Vector2(rect.Right + 1f, rect.Y), new Vector2(rect.Right + 1f, rect.Bottom + thickness), color, thickness); // right
		}

		/// <summary>
		/// Draws a rectangle with the thickness provided
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="location">Where to draw</param>
		/// <param name="size">The size of the rectangle</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public void DrawRectangle(Texture2D texture, Vector2 location, Vector2 size, Color color)
		{
			DrawRectangle(texture, new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y), color, 1.0f);
		}

		/// <summary>
		/// Draws a rectangle with the thickness provided
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="location">Where to draw</param>
		/// <param name="size">The size of the rectangle</param>
		/// <param name="color">The color to draw the rectangle in</param>
		/// <param name="thickness">The thickness of the line</param>
		public void DrawRectangle(Texture2D texture, Vector2 location, Vector2 size, Color color, float thickness)
		{
			DrawRectangle(texture, new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y), color, thickness);
		}

		public void DrawRectangle(Texture2D texture, Rectangle2D rectangle2D)
		{
			_lineDrawer.DrawLine(texture, rectangle2D.TopLine); // top
			_lineDrawer.DrawLine(texture, rectangle2D.LeftLine); // left
			_lineDrawer.DrawLine(texture, rectangle2D.BottomLine); // bottom
			_lineDrawer.DrawLine(texture, rectangle2D.RightLine); // right
		}
	}
}
