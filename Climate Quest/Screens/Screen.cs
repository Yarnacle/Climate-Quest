using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens;

public abstract class Screen
{
    protected readonly ScreenManager ScreenManager;
    protected readonly SpriteBatch SpriteBatch;
    
    protected Screen(ScreenManager manager,SpriteBatch spriteBatch)
    {
        ScreenManager = manager;
        SpriteBatch = spriteBatch;
    }
    
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(GameTime gameTime);
}