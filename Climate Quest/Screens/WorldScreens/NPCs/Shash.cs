using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class Shash: Npc
{
    private static readonly Color LanTextColor = new Color(209, 93, 66);
    
    public Shash(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.LightBlue, world, new List<Tuple<Color, string>>()
        {
            Tuple.Create(LanTextColor,"My dad says I'm getting boosted to a higher position in the town council!"),
            Tuple.Create(Color.CornflowerBlue,"No shot bro."),
            Tuple.Create(LanTextColor,"Yeah, he said I'm gonna be like, a super important advisor or something. I'm gonna be so high up, I'll need binoculars to see the ground!"),
            Tuple.Create(Color.CornflowerBlue,"That's, uh, quite the promotion, Lan. But aren't you only getting it  because your dad's the mayor?"),
            Tuple.Create(LanTextColor,"Oh, yeah. He did mention something about that. But who cares about the details? I'm gonna be, like, the king of the town or something!"),
            Tuple.Create(Color.CornflowerBlue,"Brooo that's so unfair that you're getting boosted just because of who your dad is. I have worked all my life for this position, and you stole it from me."),
            Tuple.Create(LanTextColor,"Unfair? Nah, it's all about connections, Shash. Besides, once I'm up there, I'm gonna make sure everyone gets free ice cream on Tuesdays."),
            Tuple.Create(Color.CornflowerBlue,"Free ice cream on Tuesdays? Wow... how.. generous."),
            Tuple.Create(LanTextColor,"That's the idea! I figure if I can't be the smartest or the most hardworking mayor's son, I can at least be the most popular!"),
            Tuple.Create(Color.CornflowerBlue,"Dawg you're the mayor's only son..."),
            Tuple.Create(LanTextColor,"Huh?"),
            Tuple.Create(Color.CornflowerBlue,"Jay, are you seeing this right now? How is this man more qualified than me to lead?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.CornflowerBlue,"What!? I am in every way more qualified to lead this town than Lan, who is COMPLETLY undeserving of his position. How are you allowing this corruption? That's actually messed up."),
            Tuple.Create(LanTextColor,"Yeah, Shash, you tell him!"),
            Tuple.Create(LanTextColor,"Wait, no, he's on my side. Beat his ass, Jay!"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.CornflowerBlue,"Oh, AND the mayor wants me gone, huh? Just for trying to lead this town. Nah, this town is messed up.")
        }, new Point(5, 6), new List<Point>()
        {
            new Point(5,3),
            new Point(10,3)
        },new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.CornflowerBlue,"Everyone be praying on my downfall for real...")
        })
    {

    }
    
    public override void AfterDeath()
    {
        if (GridPosition.Y == 2)
        {
            ScreenManager.Worlds["PathToHouse"].GetExits().Remove(new Point(-1, 2));
        }
        if (GridPosition.Y == 3)
        {
            ScreenManager.Worlds["PathToHouse"].GetExits().Remove(new Point(-1, 3));
        }
        ScreenManager.Worlds["Spawn"].GetNPCs()[Color.Maroon].NewDialogue(new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.IndianRed,"You got him?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.IndianRed,"Good."),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.IndianRed,"Yes, Lan is indeed my son. Regardless, you did the right thing to deal with Shash. He was a threat to the safety of this town."),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.IndianRed,"Whatever. There are more important things to worry about right now."),
            Tuple.Create(Color.IndianRed,"I suspect that there's a group plotting against me. I don't know where they meet, but I think Vorrow was one of them. Find them, and take them out. The town is counting on you.")
        });
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (Dead)
        {
            return;
        }
        if (Destination == Path.Count)
        {
            // Console.WriteLine("Pathing finished");
            if (World == ScreenManager.Worlds["RoadEnd"])
            {
                World.RemoveNPC(Color);
                ChangeWorld(ScreenManager.Worlds["CobbleRoad"],new Point(1,3),new List<Point>(){new Point(9,3)},null);
                DialogueState = State.After;
            }
            else if (World == ScreenManager.Worlds["CobbleRoad"]) {
                Path = new List<Point>()
                {
                    new Point(9,2),
                    new Point(9,3)
                };
                StartPath();
            }
        }
    }

    public override void FinishedDialogue()
    {
        StartPath();
    }
}