﻿// <auto-generated>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Synergy.VirusPrototype.Shared.Controls;
using Synergy.VirusPrototype.Shared.Scenes.Abstract;
using Synergy.VirusPrototype.Shared.Services.Abstract;

namespace Synergy.VirusPrototype.Shared.Scenes.Menu
{
	public class MenuScene : IMenuScene
	{
		private SpriteFont _font;
		private readonly SpriteBatch _spriteBatch;
		private readonly ILineDrawer _lineDrawer;
		private readonly GraphicsDevice _graphicsDevice;
		private readonly IFilledRectangleDrawer _filledRectangleDrawer;

		public MenuScene(
			SpriteBatch spriteBatch,
			GraphicsDevice graphicsDevice,
			IFilledRectangleDrawer filledRectangleDrawer,
			ContentManager contentManager)
		{
			_spriteBatch = spriteBatch;
			_graphicsDevice = graphicsDevice;
			_filledRectangleDrawer = filledRectangleDrawer;
			// _font = contentManager.Load<SpriteFont>("Fonts\\default_font");
		}

		public Task NavigateAsync()
		{
			_spriteBatch.Begin();

			//	_font = fontBakeResult.CreateSpriteFont(_graphicsDevice);
			var grid = new Grid();
			_filledRectangleDrawer.FillRectangle(new Rectangle(new Point(10, 10), new Point(50, 50)), Color.Red);
			//_spriteBatch.DrawString(_font, "The quick brown fox jumps over the lazy dog", new Vector2(0, 0), Color.White);

			_spriteBatch.End();

			return Task.CompletedTask;
		}
	}

	/// <summary>
	/// </summary>
	public static class Primitives2D
	{
		#region Private Members

		private static readonly Dictionary<String, List<Vector2>> circleCache = new Dictionary<string, List<Vector2>>();
		//private static readonly Dictionary<String, List<Vector2>> arcCache = new Dictionary<string, List<Vector2>>();
		private static Texture2D pixel;

		#endregion


		#region Private Methods

		private static void CreateThePixel(SpriteBatch spriteBatch)
		{
			pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
			pixel.SetData(new[] { Color.White });
		}


		/// <summary>
		/// Draws a list of connecting points
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// /// <param name="position">Where to position the points</param>
		/// <param name="points">The points to connect with lines</param>
		/// <param name="color">The color to use</param>
		/// <param name="thickness">The thickness of the lines</param>
		private static void DrawPoints(SpriteBatch spriteBatch, Vector2 position, List<Vector2> points, Color color, float thickness)
		{
			if (points.Count < 2)
				return;

			for (int i = 1; i < points.Count; i++)
			{
				DrawLine(spriteBatch, points[i - 1] + position, points[i] + position, color, thickness);
			}
		}


		/// <summary>
		/// Creates a list of vectors that represents a circle
		/// </summary>
		/// <param name="radius">The radius of the circle</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <returns>A list of vectors that, if connected, will create a circle</returns>
		private static List<Vector2> CreateCircle(double radius, int sides)
		{
			// Look for a cached version of this circle
			String circleKey = radius + "x" + sides;
			if (circleCache.ContainsKey(circleKey))
			{
				return circleCache[circleKey];
			}

			List<Vector2> vectors = new List<Vector2>();

			const double max = 2.0 * Math.PI;
			double step = max / sides;

			for (double theta = 0.0; theta < max; theta += step)
			{
				vectors.Add(new Vector2((float)(radius * Math.Cos(theta)), (float)(radius * Math.Sin(theta))));
			}

			// then add the first vector again so it's a complete loop
			vectors.Add(new Vector2((float)(radius * Math.Cos(0)), (float)(radius * Math.Sin(0))));

			// Cache this circle so that it can be quickly drawn next time
			circleCache.Add(circleKey, vectors);

			return vectors;
		}


		/// <summary>
		/// Creates a list of vectors that represents an arc
		/// </summary>
		/// <param name="radius">The radius of the arc</param>
		/// <param name="sides">The number of sides to generate in the circle that this will cut out from</param>
		/// <param name="startingAngle">The starting angle of arc, 0 being to the east, increasing as you go clockwise</param>
		/// <param name="radians">The radians to draw, clockwise from the starting angle</param>
		/// <returns>A list of vectors that, if connected, will create an arc</returns>
		private static List<Vector2> CreateArc(float radius, int sides, float startingAngle, float radians)
		{
			List<Vector2> points = new List<Vector2>();
			points.AddRange(CreateCircle(radius, sides));
			points.RemoveAt(points.Count - 1); // remove the last point because it's a duplicate of the first

			// The circle starts at (radius, 0)
			double curAngle = 0.0;
			double anglePerSide = MathHelper.TwoPi / sides;

			// "Rotate" to the starting point
			while ((curAngle + (anglePerSide / 2.0)) < startingAngle)
			{
				curAngle += anglePerSide;

				// move the first point to the end
				points.Add(points[0]);
				points.RemoveAt(0);
			}

			// Add the first point, just in case we make a full circle
			points.Add(points[0]);

			// Now remove the points at the end of the circle to create the arc
			int sidesInArc = (int)((radians / anglePerSide) + 0.5);
			points.RemoveRange(sidesInArc + 1, points.Count - sidesInArc - 1);

			return points;
		}

		#endregion


		#region PutPixel

		public static void PutPixel(this SpriteBatch spriteBatch, float x, float y, Color color)
		{
			PutPixel(spriteBatch, new Vector2(x, y), color);
		}


		public static void PutPixel(this SpriteBatch spriteBatch, Vector2 position, Color color)
		{
			if (pixel == null)
			{
				CreateThePixel(spriteBatch);
			}

			spriteBatch.Draw(pixel, position, color);
		}

		#endregion


		#region DrawCircle

		/// <summary>
		/// Draw a circle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="center">The center of the circle</param>
		/// <param name="radius">The radius of the circle</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <param name="color">The color of the circle</param>
		public static void DrawCircle(this SpriteBatch spriteBatch, Vector2 center, float radius, int sides, Color color)
		{
			DrawPoints(spriteBatch, center, CreateCircle(radius, sides), color, 1.0f);
		}


		/// <summary>
		/// Draw a circle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="center">The center of the circle</param>
		/// <param name="radius">The radius of the circle</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <param name="color">The color of the circle</param>
		/// <param name="thickness">The thickness of the lines used</param>
		public static void DrawCircle(this SpriteBatch spriteBatch, Vector2 center, float radius, int sides, Color color, float thickness)
		{
			DrawPoints(spriteBatch, center, CreateCircle(radius, sides), color, thickness);
		}


		/// <summary>
		/// Draw a circle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="x">The center X of the circle</param>
		/// <param name="y">The center Y of the circle</param>
		/// <param name="radius">The radius of the circle</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <param name="color">The color of the circle</param>
		public static void DrawCircle(this SpriteBatch spriteBatch, float x, float y, float radius, int sides, Color color)
		{
			DrawPoints(spriteBatch, new Vector2(x, y), CreateCircle(radius, sides), color, 1.0f);
		}


		/// <summary>
		/// Draw a circle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="x">The center X of the circle</param>
		/// <param name="y">The center Y of the circle</param>
		/// <param name="radius">The radius of the circle</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <param name="color">The color of the circle</param>
		/// <param name="thickness">The thickness of the lines used</param>
		public static void DrawCircle(this SpriteBatch spriteBatch, float x, float y, float radius, int sides, Color color, float thickness)
		{
			DrawPoints(spriteBatch, new Vector2(x, y), CreateCircle(radius, sides), color, thickness);
		}

		#endregion


		#region DrawArc

		/// <summary>
		/// Draw a arc
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="center">The center of the arc</param>
		/// <param name="radius">The radius of the arc</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <param name="startingAngle">The starting angle of arc, 0 being to the east, increasing as you go clockwise</param>
		/// <param name="radians">The number of radians to draw, clockwise from the starting angle</param>
		/// <param name="color">The color of the arc</param>
		public static void DrawArc(this SpriteBatch spriteBatch, Vector2 center, float radius, int sides, float startingAngle, float radians, Color color)
		{
			DrawArc(spriteBatch, center, radius, sides, startingAngle, radians, color, 1.0f);
		}


		/// <summary>
		/// Draw a arc
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="center">The center of the arc</param>
		/// <param name="radius">The radius of the arc</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <param name="startingAngle">The starting angle of arc, 0 being to the east, increasing as you go clockwise</param>
		/// <param name="radians">The number of radians to draw, clockwise from the starting angle</param>
		/// <param name="color">The color of the arc</param>
		/// <param name="thickness">The thickness of the arc</param>
		public static void DrawArc(this SpriteBatch spriteBatch, Vector2 center, float radius, int sides, float startingAngle, float radians, Color color, float thickness)
		{
			List<Vector2> arc = CreateArc(radius, sides, startingAngle, radians);
			//List<Vector2> arc = CreateArc2(radius, sides, startingAngle, degrees);
			DrawPoints(spriteBatch, center, arc, color, thickness);
		}

		#endregion


	}
}
