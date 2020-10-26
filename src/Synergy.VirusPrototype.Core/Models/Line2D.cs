using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Synergy.VirusPrototype.Core.Models
{
	public class Line2D
	{
		public Texture2D Pixel { get; set; }

		public Vector2 StartingPoint { get; set; }

		public Color Color { get; set; }

		/// <summary>
		/// Gets or sets the angle from the starting point.
		/// </summary>
		public float Angle { get; set; }

		public float Length { get; set; }

		public float Thickness { get; set; }
	}
}
