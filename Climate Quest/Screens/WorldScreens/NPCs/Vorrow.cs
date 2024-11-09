using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class Vorrow: Npc
{
    public Vorrow(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.DarkGreen, world, new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.GreenYellow,"Now hold your horses! What're you doin' on my property?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.GreenYellow,"Ah, blast it all! That fella thinks he can just waltz in here and demand I surrender my land? Well, tell him no. Tell him he can take that dinky plot down south if he's so desperate."),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.GreenYellow,"I don't care if he wants this land, I've sweated over this soil for nigh on half a century. I'll be darned if some bureaucrat thinks it's his land!"),
            Tuple.Create(Color.GreenYellow,"Town hall can manage just fine without it. Why, they're wringing every last cent out of us with those outrageous taxes!"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.GreenYellow,"What in tarnation do you think you're doing, pulling out a gun like that?"),
            Tuple.Create(Color.GreenYellow,"You reckon you're some sort of hero, going around killing people? Ha! \"Greater good\" my foot! That's some greater good, threatening a defenseless old man like me.")
            
        }, new Point(5, 6), null,new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.GreenYellow,"Some greater good indeed...")
        })
    {

    }
    
    public override void FinishedDialogue()
    {
        Player.SetDrawn(true);
    }

    public override void AfterDeath()
    {
        ScreenManager.Worlds["Spawn"].GetNPCs()[Color.Maroon].NewDialogue(new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.IndianRed,"Finally, you're back! It has come to my attention that a citizen in this town who goes by the name of \"Lan\" is being unjustly suppressed by someone..."),
            Tuple.Create(Color.IndianRed,"some other citizen in this town who goes by a name that currently does not reside in my memory. He is threatening the democracy of this town! Find him. Fix it. Fast.")
        });
    }
}