using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class Lain: Npc
{
    public Lain(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.Wheat, world, new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.Gold,"Well if it isn't the mayor's personal assassin himself. What brings you to all the way out here?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.Gold,"Ah. I assume that wouldn't involve... killing me... right??"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.Gold,"Ugh... is this the only thing the mayor can come up with?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.Gold,"\"Peace\". I doubt he even knows what that word means. Nothing about what he makes you do is peaceful."),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.Gold,"How can he impose a standard of peace on everyone while constantly employing violent measures?"),
            Tuple.Create(Color.Gold,"Maybe he sleeps well at night knowing his enemies are all but gone, but has he ever considered everyone else in this town? How we live in fear?"),
            Tuple.Create(Color.Gold,"No. He thinks he's so righteous, always making sure OTHER people act peacefully. What a joke."),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.Gold,"We need a new leader to replace Jay. Someone who understands peace and violence. Someone who knows this town."),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.Gold,"You're going to do something about Jay? You think you can save this town? Good luck with that, man.")
        }, new Point(5, 4), null,null)
    {

    }
    
    public override void FinishedDialogue()
    {
        ScreenManager.Worlds["Spawn"].GetNPCs()[Color.Maroon].NewDialogue(new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.IndianRed,"My star sheriff! You took them out?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.IndianRed,"W-What do you mean?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.IndianRed,"W-What are you doing with that?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.IndianRed,"What blasphemy is this? I order you to put that way. You are about to undermine all the peace we worked for!")
        });
    }
}