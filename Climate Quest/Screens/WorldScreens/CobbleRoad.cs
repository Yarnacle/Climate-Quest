using System.Collections.Generic;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens;

public class CobbleRoad: World
{
    public CobbleRoad(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.CobbleRoad, new Dictionary<Point, string>()
        {
            { new Point(-1, 2), "RoadEnd" },
            { new Point(-1,3), "RoadEnd" },
            { new Point(10, 2), "PathToHouse" },
            { new Point(10,3), "PathToHouse" }
        },false)
    {
        
    }

    public override void Enter(Player player)
    {
        base.Enter(player);
        if (NPCs.ContainsKey(Color.LightBlue) && !NPCs[Color.LightBlue].IsDead())
        {
            NPCs[Color.LightBlue].StartPath();
            player.SetDrawn(true);
        }
    }
}