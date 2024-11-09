using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class Matt: Npc
{
    public Matt(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.Tomato, world, new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.Aquamarine,"Hey pal. Can you spare a vote?"),
            Tuple.Create(Color.White,"I don't know, what are your policies?"),
            Tuple.Create(Color.Aquamarine,"My policies focus on struggling workers and the climate. I believe we must do everything to assist people and save the world!"),
            Tuple.Create(Color.White,"How do I know you actually care?"),
            Tuple.Create(Color.Aquamarine,"I've worked as a mechanic to serve as many people as possible. I have a masters degree in environmental science and understand the urgency of climate change. Additionally, I've pledged to never receive money from companies, only the people."),
            Tuple.Create(Color.White,"Wow that seems amazing!"),
            Tuple.Create(Color.Aquamarine,"Thank you! Now please vote for me so I can fight for you!"),
            Tuple.Create(Color.White,"Of course!"),
        }, new Point(7, 3), null,null)
    {
        
    }
}