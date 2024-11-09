using System.Collections.Generic;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens;

public class RoadEnd: World
{
    public RoadEnd(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.RoadEnd, new Dictionary<Point, string>()
        {
            { new Point(10, 2), "CobbleRoad" },
            { new Point(10,3), "CobbleRoad" }
        },false)
    {
        
    }
}