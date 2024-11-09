using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class Biker: Npc
{
    public Biker(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.CadetBlue, world, new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.White, "Hey, what's that thing you were riding?"),
            Tuple.Create(Color.CadetBlue, "It's a bike!"),
            Tuple.Create(Color.White, "A what?"),
            Tuple.Create(Color.CadetBlue, "A bicycle! It's a bit tough to get a hang of initially, but it's fun to ride!"),
            Tuple.Create(Color.White, "But isn't this slower than driving a car?"),
            Tuple.Create(Color.CadetBlue, "Yes, but it's more environmental friendly."),
            Tuple.Create(Color.White, "How so?"),
            Tuple.Create(Color.CadetBlue, "Cars release greenhouse gases and harmful pollutants that cause global warming and respiratory diseases."),
            Tuple.Create(Color.White, "Wow, that's awful!"),
            Tuple.Create(Color.CadetBlue, "Yeah, but if you ride a bike, you won't have any of these issues."),
            Tuple.Create(Color.White, "Okay. Thanks for informing me!"),
            Tuple.Create(Color.CadetBlue, "No problem!"),
        }, new Point(4,3), null, null)
    {
        
    }
}