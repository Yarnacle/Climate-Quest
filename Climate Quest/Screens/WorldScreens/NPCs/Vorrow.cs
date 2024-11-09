using System;
using System.Collections.Generic;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class Vorrow: Npc
{
    public Vorrow(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.DarkGreen, world, new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.White,"Why do you have a wooden trash can?"),
            Tuple.Create(Color.GreenYellow,"Now hold your horses! What're you're looking at is a COMPOSTING BIN."),
            Tuple.Create(Color.White,"What?"),
            Tuple.Create(Color.GreenYellow,"Normally, food waste is thrown away in standard trash cans. In this bad boy, it's converted into soil to be reused for growing food."),
            Tuple.Create(Color.White,"What difference does it make?"),
            Tuple.Create(Color.GreenYellow,"It is more resource-efficient, wasteless, and sustainable to discard food waste and other organic waste into composting bins, rather than standard trash cans.")
        }, new Point(5, 6), null,new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.GreenYellow,"Some greater good indeed...")
        })
    {

    }
    
    public override void FinishedDialogue()
    {
        Textures.SoundEffects.DialogueFinished.Play();
        // new climate action unlocked: composting
        Player.Collection.NewUnlock("Composting");
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