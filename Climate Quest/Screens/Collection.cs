using System;
using System.Collections.Generic;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens;

public class Collection : TextPopup
{
    private double _startTime;
    private bool _showPopup = false;
    private List<String> ClimateActions = new List<string>();
    
    public Collection(ScreenManager manager, SpriteBatch spriteBatch, Rectangle box, SpriteFont font, string text,
        Color color, float scale, int padding, Texture2D background) : base(manager, spriteBatch,new Rectangle(200,200,600,600), font,text,color,scale,padding,background)
    {
    }

    public void NewUnlock(String action,GameTime gameTime)
    {
        _startTime = gameTime.TotalGameTime.TotalMilliseconds;
        _showPopup = true;
        ClimateActions.Add(action);
    }

    public override void Update(GameTime gameTime)
    {
        if ((gameTime.TotalGameTime.TotalMilliseconds - _startTime) / 1000 > 5)
        {
            _showPopup = false;
        }
    }

    public override void Draw(GameTime gameTime)
    {
        if (_showPopup)
        {
            SpriteBatch.Draw(Textures.General.UnlockSplash,Box,Color.White);
        }
    }
}