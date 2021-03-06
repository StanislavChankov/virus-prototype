﻿// <auto-generated>
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Synergy.VirusPrototype.Core.Builders.Abstract;
using Synergy.VirusPrototype.Core.Controls;
using Synergy.VirusPrototype.Core.Views;
using Synergy.VirusPrototype.Shared.Extensions;
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
		private readonly IContentTextureBuilder _contentTextureBuilder;
		private readonly IFilledRectangleDrawer _filledRectangleDrawer;

		public MenuScene(
			SpriteBatch spriteBatch,
			GraphicsDevice graphicsDevice,
			IContentTextureBuilder contentTextureBuilder,
			IFilledRectangleDrawer filledRectangleDrawer,
			ContentManager contentManager)
		{
			_spriteBatch = spriteBatch;
			_graphicsDevice = graphicsDevice;
			_contentTextureBuilder = contentTextureBuilder;
			_filledRectangleDrawer = filledRectangleDrawer;
			// _font = contentManager.Load<SpriteFont>("Fonts\\default_font");
		}

		public Task NavigateAsync()
		{
			_spriteBatch.Begin();

			var pixel = _spriteBatch.GetPixel();

			//	_font = fontBakeResult.CreateSpriteFont(_graphicsDevice);
			var content = _contentTextureBuilder.GetGridBuilder()
				.Create()
					.WithRow(1, GridUnitType.Star)
					.WithRow(2, GridUnitType.Star)
				.Build(pixel);

			_spriteBatch.Draw(content.Texture, new Vector2(0, 0), Color.White);

			// _filledRectangleDrawer.FillRectangle(new Rectangle(new Point(10, 10), new Point(50, 50)), Color.Red);
			//_spriteBatch.DrawString(_font, "The quick brown fox jumps over the lazy dog", new Vector2(0, 0), Color.White);

			_spriteBatch.End();

			return Task.CompletedTask;
		}
	}
}
