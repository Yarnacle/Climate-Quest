using System;
using System.Collections.Generic;
using ClimateQuest.GameTextures;
using ClimateQuest.Screens.WorldScreens.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens;

public class FarmRoad: World
{
    public FarmRoad(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.FarmRoad, new Dictionary<Point, string>()
        {
            {new Point(2,-1),"FarmBend"},
            {new Point(3,-1),"FarmBend"},
            {new Point(4,-1),"FarmBend"},
            {new Point(2,10),"SpawnEntrance"},
            {new Point(3,10),"SpawnEntrance"},
            {new Point(4,10),"SpawnEntrance"}
        },false)
    {
        
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Enter(Player player)
    {
        base.Enter(player);
        if (NPCs.ContainsKey(Color.Purple) && !NPCs[Color.Purple].IsDead()) {
            ((Robber)NPCs[Color.Purple]).StartPath();
            Player.SetDrawn(true);
        }
    }
}