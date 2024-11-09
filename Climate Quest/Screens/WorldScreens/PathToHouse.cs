using System.Collections.Generic;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens;

public class PathToHouse: World
{
    public PathToHouse(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.PathToHouse, new Dictionary<Point, string>()
        {
            { new Point(2, -1), "SpawnEntrance" },
            { new Point(3,-1), "SpawnEntrance" },
            {new Point(4,-1),"SpawnEntrance"},
            {new Point(5,10),"Cabin1"},
            {new Point(6,10),"Cabin1"},
            {new Point(-1,2),"CobbleRoad"},
            {new Point(-1,3),"CobbleRoad"}
        },false)
    {
        
    }
}