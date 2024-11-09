using System;
using System.Text;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens;

public class Collection : Screen
{
    public Collection(ScreenManager manager, SpriteBatch spriteBatch, Rectangle box, SpriteFont font, string text,
        Color color, float scale, int padding, Texture2D background) : base(manager, spriteBatch)
    {
        
    }
}