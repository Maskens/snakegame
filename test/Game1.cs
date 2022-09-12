namespace test;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Player player;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = GameConf.SCREEN_WIDTH;  // set this value to the desired width of your window
        _graphics.PreferredBackBufferHeight = GameConf.SCREEN_HEIGHT;   // set this value to the desired height of your window
        _graphics.ApplyChanges();

        Content.RootDirectory = "Content";
        IsMouseVisible = true;

    }

    protected override void Initialize()
    {
        player = new Player(30, 30, 16, 16);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (Keyboard.GetState().IsKeyDown(Keys.Left)) {
            player.move(MovingDir.LEFT);
	    }

        if (Keyboard.GetState().IsKeyDown(Keys.Right)) {
            player.move(MovingDir.RIGHT);
	    }

        if (Keyboard.GetState().IsKeyDown(Keys.Down)) {
            player.move(MovingDir.DOWN);
	    }

        if (Keyboard.GetState().IsKeyDown(Keys.Up)) {
            player.move(MovingDir.UP);
	    }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        player.Draw(_spriteBatch, GraphicsDevice);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}

