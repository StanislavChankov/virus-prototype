using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Synergy.VirusPrototype.Core.Builders.Abstract;
using Synergy.VirusPrototype.Core.Controls;
using Synergy.VirusPrototype.Core.Factories;
using Synergy.VirusPrototype.Shared.Services.Abstract;

namespace Synergy.VirusPrototype.Core.Builders
{
	public class GridBuilder : IGridBuilder
	{
		private readonly SpriteBatch _spriteBatch;
		private readonly ILineDrawer _lineDrawer;
		private readonly IRectangleDrawer _rectangleDrawer;
		private Grid _grid;

		public GridBuilder(
			SpriteBatch spriteBatch,
			ILineDrawer lineDrawer,
			IRectangleDrawer rectangleDrawer)
		{
			_spriteBatch = spriteBatch;
			_lineDrawer = lineDrawer;
			_rectangleDrawer = rectangleDrawer;
		}

		public IGridBuilder Create()
		{
			_grid = new Grid(_rectangleDrawer, _spriteBatch.GraphicsDevice);

			return this;
		}

		public Grid Build(Texture2D texture)
		{
			_grid.Texture = texture;

			var gridHeight = _spriteBatch.GraphicsDevice.Viewport.Height;
			var gridWidth = _spriteBatch.GraphicsDevice.Viewport.Width;
			var topLeft = new Point(0, 0);
			var bottomRight = new Point(gridWidth, gridHeight);

			double rowHeightCoeficient = gridHeight / _grid.Rows.Sum(r => r.Height.Value);

			_rectangleDrawer.DrawRectangle(_grid.Texture, new Rectangle(topLeft, bottomRight), Color.Red);

			foreach (var row in _grid.Rows)
			{
				float rowHeight = (float)(row.Height.Value * rowHeightCoeficient);

				var line = Line2DFactory.GetLine(new Vector2(0, rowHeight), new Vector2(_grid.Width, rowHeight), Color.Blue);

				_lineDrawer.DrawLine(_grid.Texture, line);
			}

			return _grid;
		}

		public IGridBuilder WithRow(double value, GridUnitType gridUnitType)
		{
			_grid.Rows.Add(new RowDefinition { Height = new GridLength(value, gridUnitType) });

			return this;
		}
	}
}
