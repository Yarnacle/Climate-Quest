using System.Collections.Generic;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens;

public class FarmBend: World
{
    public FarmBend(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.FarmBend, new Dictionary<Point, string>()
        {
            { new Point(2, 10), "FarmRoad" },
            { new Point(3,10), "FarmRoad" },
            {new Point(4,10),"FarmRoad"},
            {new Point(10,3),"Cabin2"},
            {new Point(10,4),"Cabin2"}
        },false)
    {
        
    }
}