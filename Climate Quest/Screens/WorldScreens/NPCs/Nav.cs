using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class Nav: Npc
{
    public Nav(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.Pink, world, new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.HotPink,"Mr. Sheriff! How can you call yourself a bringer of JUSTICE when 10 minutes ago you KILLED my brother just because he borrowed the mayor's favorite novelty pen without asking?"),
            Tuple.Create(Color.HotPink,"He BORROWED a PEN. HOW is that a crime worthy of death?! Does the mayor think himself a god, sentencing all those who ever-so-slightly bother him?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.HotPink,"Just... quiet. I'm done with this crap. What an L town. What an L mayor. What an L sheriff.")
        }, new Point(5, 2), new List<Point>()
        {
            new Point(5,5),
            new Point(8,5),
            new Point(8,10)
        },null)
    {

    }

    public override void FinishedDialogue()
    {
        StartPath();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (Destination == Path.Count)
        {
            // Console.WriteLine("Pathing finished");
            World.RemoveNPC(Color);
        }
    }
}