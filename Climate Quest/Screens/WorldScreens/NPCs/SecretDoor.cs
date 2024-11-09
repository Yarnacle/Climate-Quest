using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class SecretDoor: Npc
{
    public SecretDoor(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.Gold, world, null, new Point(9,8), new List<Point>()
        {
            new Point(11,8)
        },null)
    {
    }

    public override void InitiateDialogue()
    {
        StartPath();
    }

    public override void Die()
    {
        return;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (Destination == Path.Count)
        {
            if (GridPosition == new Point(9, 8))
            { 
                NewPath(new List<Point>() { new Point(11, 8) });
            }
        }
    }
}