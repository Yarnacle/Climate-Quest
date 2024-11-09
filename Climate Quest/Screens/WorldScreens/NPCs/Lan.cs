using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class Lan: Npc
{
    public Lan(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.Beige, world, new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.White, "Whoa, what's that blue bin?"),
            Tuple.Create(Color.LightBlue,"That's a recycling bin."),
            Tuple.Create(Color.White, "What's recycling?"),
            Tuple.Create(Color.LightBlue, "The action or process of converting waste into reusable material!"),
            Tuple.Create(Color.White, "What's the point of recycling?"),
            Tuple.Create(Color.LightBlue, "Recycling reduces waste, conserves resources, saves energy, cuts pollution, and slows climate change!"),
            Tuple.Create(Color.White, "I see! Thank you so much for the info!"),
            Tuple.Create(Color.LightBlue, "No problem!"),
        }, new Point(4, 7), null,null)
    {

    }
}