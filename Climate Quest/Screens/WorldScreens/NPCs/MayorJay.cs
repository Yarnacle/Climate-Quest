using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class MayorJay: Npc
{
    public MayorJay(ScreenManager manager,SpriteBatch spriteBatch,World world) : base(manager,spriteBatch, Color.Maroon,world,new List<Tuple<Color,string>>()
    {
        Tuple.Create(Color.IndianRed,"ClimateTown is in a Climate Crisis! You have been recruited as the Climate Caretaker to learn what we can do and spread the word."),
        Tuple.Create(Color.White,"Okay...? Where do I begin?"),
        Tuple.Create(Color.IndianRed,"Uh, maybe try asking other people. aACK. Man, this air quality sucks. Anyway, good luck!"),
    },new Point(6,4),null,new List<Tuple<Color, string>>()
    {
        Tuple.Create(Color.IndianRed,"How could you...? What happened to... peace...?")
    })
    {
    }

    public override void FinishedDialogue()
    {
        ScreenManager.Worlds["SpawnEntrance"]
            .AddNPC(new Robber(ScreenManager, SpriteBatch, ScreenManager.Worlds["SpawnEntrance"]));
        ScreenManager.Worlds["FarmBend"].AddNPC(new Vorrow(ScreenManager,SpriteBatch,ScreenManager.Worlds["FarmBend"]));
        ScreenManager.Worlds["Cabin1"]
            .AddNPC(new Chenny(ScreenManager, SpriteBatch, ScreenManager.Worlds["Cabin1"]));
        ScreenManager.Worlds["Cabin1"].AddNPC(new Pav(ScreenManager, SpriteBatch, ScreenManager.Worlds["Cabin1"]));
        ScreenManager.Worlds["Cabin2"].AddNPC(new Pyro(ScreenManager, SpriteBatch, ScreenManager.Worlds["Cabin2"]));
        ScreenManager.Worlds["Cabin2"].AddNPC(new Matt(ScreenManager, SpriteBatch, ScreenManager.Worlds["Cabin2"]));
        ScreenManager.Worlds["CobbleRoad"].AddNPC(new Biker(ScreenManager, SpriteBatch, ScreenManager.Worlds["CobbleRoad"]));
        ScreenManager.Worlds["RoadEnd"].AddNPC(new Lan(ScreenManager, SpriteBatch, ScreenManager.Worlds["RoadEnd"]));
    }

    public override void AfterDeath()
    {
        ScreenManager.Worlds["SpawnEntrance"].AddNPC(new Raaj(ScreenManager,SpriteBatch,ScreenManager.Worlds["SpawnEntrance"]));
        Player.SetTexture(Textures.General.MouthedJay);
    }
}