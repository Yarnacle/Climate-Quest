using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class Pav: Npc
{
    private bool _rambling;
    
    public Pav(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
    Color.DarkOrange, world, new List<Tuple<Color, string>>()
    {
        Tuple.Create(Color.White,"..."),
        Tuple.Create(Color.DarkOrange,"Bro Chenny is such an opp!"),
        Tuple.Create(Color.LightGreen,"Sooo who forgot to file our taxes?"),
        Tuple.Create(Color.DarkOrange,"Sooooooo who pays for this house?"),
        Tuple.Create(Color.LightGreen,"Aight bro. You're only where you are today because of me."),
        Tuple.Create(Color.DarkOrange,"Nah nah nah, I carried you though college. YOU'RE where YOU are because of ME."),
        Tuple.Create(Color.LightGreen,"Who kept giving you that lil physics plug?"),
        Tuple.Create(Color.DarkOrange,"Bro the sheriff can HEAR YOU."),
        Tuple.Create(Color.LightGreen,"YOU'RE THE ONE YELLING!"),
        Tuple.Create(Color.DarkOrange,"CALM YO ASS DOWN."),
        Tuple.Create(Color.LightGreen,"NAH I'M GONNA BOX YOUR ASS UP-"),
        Tuple.Create(Color.DarkOrange,"OH. OOOHHH. SO THAT'S HOW IT IS. YOU'RE NOT READY FOR THIS.")
    }, new Point(5, 6), null,new List<Tuple<Color, string>>()
    {
        Tuple.Create(Color.DarkOrange,"Clear... my... search history..."),
        Tuple.Create(Color.LightGreen,"No shot you actually killed him. But don't call for medical attention! I don't want to be in debt for the rest of my life...")
    })
    {

        _rambling = false;
    }

    public void SetRambling(bool rambling)
    {
        _rambling = rambling;
    }

    public override void FinishedDialogue()
    {
        Player.SetDrawn(true);
    }

    public override void AfterDeath()
    {
        ScreenManager.Worlds["Spawn"].GetNPCs()[Color.Maroon].NewDialogue(new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.IndianRed,"Well done. You're on a roll!"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.IndianRed,"Those guys were really going at it every single day. It's a wonder how they even got together in the first place if you ask me."),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.IndianRed,"Okay, back to business. Recently, there has been a surge in incidents involving farmers being hostile towards new nearby establishments."),
            Tuple.Create(Color.IndianRed,"I think it's time we put our foot down and remind them who calls the shots in this town. How about we start with Vorrow and his farm just north of here?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.IndianRed,"Alright then! We make a good team.")
        });
        
        ((Chenny)World.GetNPCs()[Color.LightGreen]).SetRambling(true);
    }
    
    public override void InitiateDialogue()
    {
        if (_rambling)
        {
            var rand = new Random();
            Dialogue = new List<Tuple<Color, string>>()
            {
                Tuple.Create<Color, string>(Color.DarkOrange, Chenny.Lyrics[rand.Next(0, Chenny.Lyrics.Count)])
            };
        }
        base.InitiateDialogue();

    }
    
    public override void NextDialogue()
    {
        base.NextDialogue();

        if (!_rambling)
        {
            return;
        }
        
        var rand = new Random();
        NewDialogue(new List<Tuple<Color, string>>()
        {
            Tuple.Create<Color, string>(Color.DarkOrange, Chenny.Lyrics[rand.Next(0, Chenny.Lyrics.Count)])
        });
    }
}