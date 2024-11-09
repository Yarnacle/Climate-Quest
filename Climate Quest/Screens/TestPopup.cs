using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens;

public class TestPopup: Popup
{
    public TestPopup(ScreenManager manager,SpriteBatch spriteBatch,Rectangle box) : base(manager,spriteBatch,box)
    {
        
    }
    
    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Draw(Textures.General.Lan, Box, Color.White);
    }
}