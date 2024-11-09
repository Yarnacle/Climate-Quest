using System;
using System.Collections.Generic;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens;

public class Collection : Screen
{
    private List<String> ClimateActions = new List<string>();
    
    public Collection(ScreenManager manager, SpriteBatch spriteBatch, Rectangle box, SpriteFont font, string text,
        Color color, float scale, int padding, Texture2D background) : base(manager, spriteBatch)
    {
    }

    public void AddClimateAction(String action)
    {
        ClimateActions.Add(action);
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(GameTime gameTime)
    {
        
    }
}