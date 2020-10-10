﻿// <auto-generated>
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Synergy.VirusPrototype.Shared
{
	public class VirusPrototypeGame : Game
	{
		private readonly GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		/// <summary>
		/// The texture is what we view on the screen.
		/// </summary>
		private Texture2D _texture;

		/// <summary>
		/// The position is where our object is relative to the top-left corner.
		/// </summary>
		private Vector2 _position;

		private SpriteSheet spriteSheet;

		public VirusPrototypeGame()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			IsMouseVisible = true;

			spriteSheet = new SpriteSheet("2d\\SmallKnightRun", 176, 212, 10, 10, true);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			// Use the content manager to load our texture
			// _texture = Content.Load<Texture2D>("2d\\KnightRun");

			// (0, 0) is the top-left corner
			_position = new Vector2(0, 0);
			spriteSheet.LoadContent(Content, GraphicsDevice);
			// TODO: use this.Content to load your game content here
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			if (gameTime.TotalGameTime.TotalSeconds > 5)
			{
				spriteSheet.Update(gameTime);
			}

			base.Update(gameTime);

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// Let's MonoGame know we're about to add some sprites to the batcher
			_spriteBatch.Begin();

			// TODO: Add your drawing code here
			_spriteBatch.Draw(spriteSheet.CurrentFrame, Vector2.Zero, Color.White);
			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
