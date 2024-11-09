using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class Robber: Npc
{

    public Robber(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.Purple, world, new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.MediumPurple, "My life is ruined!"),
            Tuple.Create(Color.White, "What happened?"),
            Tuple.Create(Color.MediumPurple, "See this? It was my HOUSE. It looks like this because a hurricane blew through it."),
            Tuple.Create(Color.MediumPurple, "The increasing amount of extreme weather events is being caused by irresponsible and unsustainable behaviors. Climate Caretaker, I'm counting on you to save us!"),
        }, new Point(1, 4), null,null)
    {

    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (Dead)
        {
            return;
        }
        
    }

    public override void FinishedDialogue()
    {
        
    }
}