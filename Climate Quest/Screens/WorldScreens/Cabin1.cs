using System.Collections.Generic;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens;

public class Cabin1: World
{
    public Cabin1(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.Cabin1, new Dictionary<Point, string>
        {
            { new Point(5, -1), "PathToHouse" },
            { new Point(6, -1), "PathToHouse" }
        },false)
    {
        
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (NPCs.Count != 0)
        {
            if (NPCs[Color.DarkOrange].IsDead())
            {
                Player.SetDrawn(false);
            }
            else if (NPCs[Color.LightGreen].IsDead())
            {
                Player.SetDrawn(false);
            }
        }
    }
}