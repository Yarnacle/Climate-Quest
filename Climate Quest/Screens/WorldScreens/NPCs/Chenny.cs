using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class Chenny: Npc
{
    public static readonly List<string> Lyrics = new(){
        "...I was elected to lead, the people trust my judgement best.\nDon't underestimate my care, I act in their best interest.",
        "...As president I hold the launch codes, this power's mine to use.\nBut some think I should not have sole control over the nukes...",
        "...I should keep control, like truman did before.\nWith japan back in 45 the bomb ended the war...",
        "...Executive power lets me build up our nuclear arsenal.\nAs Eisenhower did in the Cold War, projecting power global...",
        "...I hear your views and understand, but I need quick command.\n If there's a threat detected I'll wield this with power respected..."
    };

    private bool _rambling;

    public Chenny(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
    Color.LightGreen, world, null, new Point(2, 6), null,new List<Tuple<Color, string>>()
    {
        Tuple.Create(Color.LightGreen,"Clear... my... search history..."),
        Tuple.Create(Color.DarkOrange,"No shot you actually killed him. But don't call for medical attention! I don't want to be in debt for the rest of my life...")
    })
    {
        _rambling = false;
    }

    public void SetRambling(bool rambling)
    {
        _rambling = rambling;
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
        
        ((Pav)World.GetNPCs()[Color.DarkOrange]).SetRambling(true);
    }

    public override void InitiateDialogue()
    {
        base.InitiateDialogue();
        
        if (!_rambling)
        {
            return;
        }

        var rand = new Random();
        Dialogue = new List<Tuple<Color, string>>()
        {
            Tuple.Create<Color, string>(Color.LightGreen, Lyrics[rand.Next(0, Lyrics.Count)])
        };
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
            Tuple.Create<Color, string>(Color.LightGreen, Lyrics[rand.Next(0, Lyrics.Count)])
        });
    }
}