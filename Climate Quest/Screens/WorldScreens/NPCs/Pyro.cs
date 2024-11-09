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
            Tuple.Create(PyroColor,"Hey pal. Can you spare an old fellow a vote?"),
            Tuple.Create(Color.White,"I don't know. What are your policies?"),
            Tuple.Create(PyroColor,"I don't have policies. I just listen to what my donaters say."),
            Tuple.Create(Color.White,"What do you mean?"),
            Tuple.Create(PyroColor,"I get paid big bucks by lobbying groups. Most of them are companies whom I always support."),
            Tuple.Create(Color.White,"What do the companies want you to do?"),
            Tuple.Create(PyroColor, "Great question. When I become mayor, they want me to cut down every tree and destroy all renewable energy sources."),
            Tuple.Create(Color.White,"But that would destroy the world!"),
            Tuple.Create(PyroColor,"Nuh-uh. I only have a third grade education, but trust me...I know more than any other scientist in the world."),
            Tuple.Create(Color.White,"But what if you believed those policies would destoy the world?"),
            Tuple.Create(PyroColor,"I wouldn't give a damn. I just care about money. If I was paid to kill every homeless person here I would."),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(PyroColor,"So...you voting for me?"),
            
        }, new Point(7,6), null,null)
    {

    }

    public override void FinishedDialogue()
    {
        base.FinishedDialogue();
        Player.Collection.NewUnlock("Voting");
    }
}