using System.Collections.Generic;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens;

public class Fadeout: FullScreen
{
    private int _frames;
    private TextPopup _titleText;
    private TextPopup _titleText2;
    
    public Fadeout(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch)
    {
        _frames = 0;
        _titleText = new TextPopup(manager, spriteBatch, new Rectangle(150, 300, 500, 500), Textures.General.Font,
            "Jay", Color.Black, 3, 0, Textures.General.Transparent,true);
        _titleText2 = new TextPopup(manager, spriteBatch, new Rectangle(150, 500, 500, 500), Textures.General.Font,
            "Town", Color.Black, 3, 0, Textures.General.Transparent,true);
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Draw(Textures.General.SolidColor,FullScreen.Box,Color.White * (_frames / 180f));
        if (_frames > 240)
        {
            _titleText.Draw(gameTime);
        }

        if (_frames > 270)
        {
            _titleText2.Draw(gameTime);
        }
    }

    public override void Update(GameTime gameTime)
    {
        _frames++;
    }
}