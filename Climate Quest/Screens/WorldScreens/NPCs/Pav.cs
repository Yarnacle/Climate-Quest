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
        Tuple.Create(Color.White,"What's with the \"Energy Star\" label on your air conditioner?"),
        Tuple.Create(Color.DarkOrange,"Oh, that? That means that it's Energy Star certified. Energy Star is a program run by the Environmental Protection Agency to set standards on energy efficiency."),
        Tuple.Create(Color.DarkOrange,"The Energy Star label certifies that this appliance is energy efficient. I always look for Energy Star certified products to reduce my carbon footprint and contribute to a healthier world."),
        Tuple.Create(Color.White,"Cool, I'll take notice of that now.")
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
        // new climate action locked: energy efficient applications
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