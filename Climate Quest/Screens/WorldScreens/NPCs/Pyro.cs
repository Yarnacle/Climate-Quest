using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class Pyro: Npc
{
    private static readonly Color PyroColor = new Color(0, 200, 200);
    public Pyro(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.Honeydew, world, new List<Tuple<Color, string>>()
        {
            Tuple.Create(PyroColor,"Hey pal. Looking for something?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(PyroColor,"Get lost."),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.Aquamarine,"You think we care if you're the \"sheriff\"? All you know how to do is kill. You're just a brat with a gun."),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.Aquamarine,"You're not fooling anybody. We know what you did to Jur."),
            Tuple.Create(PyroColor,"Of course, we're glad he never got to detonate, but there are OTHER ways to achieve that... ways that DON'T end up with Jur dead and his sister without family."),
            Tuple.Create(Color.Aquamarine,"Can you just leave us alone?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(PyroColor,"We're just a group of people fighting back against the injustice of this town."),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.Aquamarine,"So we offended some people. Big deal. A small price to pay for liberty."),
            
        }, new Point(7,6), null,null)
    {

    }
}