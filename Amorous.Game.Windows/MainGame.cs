using Amorous.Mod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MainGame : Game
{
	public MainGame(bool safeMode)
	{
		GraphicsDeviceManager graphicsDeviceManager;
		if (!safeMode)
		{
			DisplayMode currentDisplayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
			graphicsDeviceManager = new GraphicsDeviceManager(this)
			{
				IsFullScreen = true,
				PreferredBackBufferWidth = currentDisplayMode.Width,
				PreferredBackBufferHeight = currentDisplayMode.Height,
				SynchronizeWithVerticalRetrace = true
			};
		}
		else
		{
			graphicsDeviceManager = new GraphicsDeviceManager(this)
			{
				IsFullScreen = false,
				PreferredBackBufferWidth = 1024,
				PreferredBackBufferHeight = 768,
				SynchronizeWithVerticalRetrace = true
			};
		}
        Window.Title = $"Amorous v{_JtvLPSB9rTZpd39g72YzyIyL4dE._7Ndy6PC2a2LH0KN1HymnT4ABjHz} (Windows, Modded)";
        Content.RootDirectory = "Content";
		_gameInstance = new _drFW6OzyMF8ZDlRgOIZiVzGGOBb(this, graphicsDeviceManager, !safeMode);
		_modLoader = new ModLoader(this, _gameInstance);
	}

	protected override void Initialize()
	{
		_gameInstance._2yEsnTDA78XAQWbRmJumBkwidEr();
		_modLoader.Initialize();
		base.Initialize();
	}

	protected override void LoadContent()
	{
		_gameInstance._balv0yyP3CJxGJdCa3HrPhp4EmR();
		_modLoader.LoadContent();
		base.LoadContent();
	}

	protected override void UnloadContent()
	{
		_gameInstance._6HoRmghKQC4aYgxwSoceg6B7IhS();
		_modLoader.UnloadContent();
		base.UnloadContent();
	}

	protected override void Update(GameTime gameTime)
	{
		if (IsActive)
		{
			_gameInstance._0Tzq0AO7rxiUfDHc8QgmJ07qWjL(gameTime);
            _modLoader.Update(gameTime);
		}
		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		_gameInstance._juuVBmrIlPJhFJ0egTG7ZJ5J0b7(gameTime);
        _modLoader.Draw(gameTime);
		base.Draw(gameTime);
	}

	private readonly _ReSMQinwfLqHErTI2lafWxQJw9B _gameInstance;
    private readonly ModLoader _modLoader;
}