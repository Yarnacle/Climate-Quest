using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ClimateQuest.Screens;
using ClimateQuest.GameTextures;

// HI

namespace ClimateQuest;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private ScreenManager _screenManager;

    private static KeyboardState _kb = Keyboard.GetState();
    private static KeyboardState _oldKb;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 1000;
        _graphics.PreferredBackBufferHeight = 1000;
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
    }

    // protected override void Initialize()
    // {
    //     
    //     base.Initialize();
    // }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Textures.Load(GraphicsDevice,Content);
        _screenManager = new ScreenManager(_spriteBatch);
        _screenManager.SetBackgroud(new HomeScreen(_screenManager,_spriteBatch));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        _screenManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise);

        _screenManager.Draw(gameTime);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
    public static bool IsKeyPressed(Keys key)
    {
        return _kb.IsKeyDown(key) && !_oldKb.IsKeyDown(key);
    }

    public static bool IsKeyDown(Keys key)
    {
        return _kb.IsKeyDown(key);
    }

    public static void UpdateKb()
    {
        _oldKb = _kb;
        _kb = Keyboard.GetState();
    }
}
