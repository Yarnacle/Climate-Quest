using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using ClimateQuest.GameTextures;
using ClimateQuest.Screens.WorldScreens.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens;

public class SpawnEntrance: World
{
    
    public SpawnEntrance(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.SpawnEntrance, new Dictionary<Point, string>()
        {
            { new Point(10, 4), "Spawn" },
            { new Point(10, 5), "Spawn" },
            {new Point(2,-1),"FarmRoad"},
            {new Point(3,-1),"FarmRoad"},
            {new Point(4,-1),"FarmRoad"},
            {new Point(2,10),"PathToHouse"},
            {new Point(3,10),"PathToHouse"},
            {new Point(4,10),"PathToHouse"}
        },false)
    {
    }
}