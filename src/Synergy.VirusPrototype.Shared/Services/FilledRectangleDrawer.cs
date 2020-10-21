using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Synergy.VirusPrototype.Shared.Extensions;
using Synergy.VirusPrototype.Shared.Services.Abstract;

namespace Synergy.VirusPrototype.Shared.Services
{
	public class FilledRectangleDrawer : IFilledRectangleDrawer
	{
		private readonly SpriteBatch _spriteBatch;

		public FilledRectangleDrawer(SpriteBatch spriteBatch)
		{
			_spriteBatch = spriteBatch;
		}

		/// <summary>
		/// Draws a filled rectangle
		/// </summary>
		/// <param name="rect">The rectangle to draw</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public void FillRectangle(Rectangle rect, Color color)
		{
			using var pixel = _spriteBatch.GetPixel();

			// Simply use the function already there
			_spriteBatch.Draw(pixel, rect, color);
		}

		/// <summary>
		/// Draws a filled rectangle
		/// </summary>
		/// <param name="rect">The rectangle to draw</param>
		/// <param name="color">The color to draw the rectangle in</param>
		/// <param name="angle">The angle in radians to draw the rectangle at</param>
		public void FillRectangle(Rectangle rect, Color color, float angle)
		{
			using var pixel = _spriteBatch.GetPixel();

			_spriteBatch.Draw(pixel, rect, null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
		}

		/// <summary>
		/// Draws a filled rectangle
		/// </summary>
		/// <param name="location">Where to draw</param>
		/// <param name="size">The size of the rectangle</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public void FillRectangle(Vector2 location, Vector2 size, Color color)
		{
			FillRectangle(location, size, color, 0.0f);
		}

		/// <summary>
		/// Draws a filled rectangle
		/// </summary>
		/// <param name="location">Where to draw</param>
		/// <param name="size">The size of the rectangle</param>
		/// <param name="angle">The angle in radians to draw the rectangle at</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public void FillRectangle(Vector2 location, Vector2 size, Color color, float angle)
		{
			using var pixel = _spriteBatch.GetPixel();

			// stretch the pixel between the two vectors
			_spriteBatch.Draw(pixel,
							 location,
							 null,
							 color,
							 angle,
							 Vector2.Zero,
							 size,
							 SpriteEffects.None,
							 0);
		}

		/// <summary>
		/// Draws a filled rectangle
		/// </summary>
		/// <param name="x">The X coord of the left side</param>
		/// <param name="y">The Y coord of the upper side</param>
		/// <param name="w">Width</param>
		/// <param name="h">Height</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public void FillRectangle(float x, float y, float w, float h, Color color)
		{
			FillRectangle(new Vector2(x, y), new Vector2(w, h), color, 0.0f);
		}

		/// <summary>
		/// Draws a filled rectangle
		/// </summary>
		/// <param name="x">The X coord of the left side</param>
		/// <param name="y">The Y coord of the upper side</param>
		/// <param name="w">Width</param>
		/// <param name="h">Height</param>
		/// <param name="color">The color to draw the rectangle in</param>
		/// <param name="angle">The angle of the rectangle in radians</param>
		public void FillRectangle(float x, float y, float w, float h, Color color, float angle)
		{
			FillRectangle(new Vector2(x, y), new Vector2(w, h), color, angle);
		}
	}
}
