using Microsoft.Extensions.Options;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Synergy.VirusPrototype.Shared.Navigation.Abstract;
using Synergy.VirusPrototype.Shared.Options;

namespace Synergy.VirusPrototype.Shared
{
	public class GameStartup : Game
	{
		private const int FrameWidth = 176;
		private const int FrameHeight = 212;
		private const int FramesInX = 10;
		private const int TotalFrames = 10;
		private readonly GraphicsDeviceManager _graphics;
		private readonly ISceneNavigator _sceneNavigator;
		private SpriteBatch _spriteBatch;

		/// <summary>
		/// The position is where our object is relative to the top-left corner.
		/// </summary>
		private Vector2 _position;

		private SpriteSheet spriteSheet;

		public GameStartup(
			IOptions<PageOptions> options,
			ISceneNavigator sceneNavigator)
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			_sceneNavigator = sceneNavigator;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			IsMouseVisible = true;

			spriteSheet = new SpriteSheet("2d\\SmallKnightRun", FrameWidth, FrameHeight, FramesInX, TotalFrames, true);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			// Use the content manager to load our texture

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

			spriteSheet.Update(gameTime);

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
