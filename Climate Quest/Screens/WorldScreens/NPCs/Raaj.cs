using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class Raaj: Npc
{
    public Raaj(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.DarkBlue, world, new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.White,"Recently, the position of town sheriff opened up. Would you like to fill it?")
        }, new Point(3,4), null,null)
    {
        
    }

    public override void FinishedDialogue()
    {
        ScreenManager.End();
    }
}