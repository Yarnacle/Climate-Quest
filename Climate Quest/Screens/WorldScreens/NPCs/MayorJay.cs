using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public class MayorJay: Npc
{
    private int _plotProgress;
    
    public MayorJay(ScreenManager manager,SpriteBatch spriteBatch,World world) : base(manager,spriteBatch, Color.Maroon,world,new List<Tuple<Color,string>>()
    {
        Tuple.Create(Color.IndianRed,"Hello! Ready for your next task?"),
        Tuple.Create(Color.White,"..."),
        Tuple.Create(Color.IndianRed,"Talkative as usual. Anyway there's a ROBBER on the loose. Get him please.")
    },new Point(6,4),null,new List<Tuple<Color, string>>()
    {
        Tuple.Create(Color.IndianRed,"How could you...? What happened to... peace...?")
    })
    {
        _plotProgress = 0;
    }

    public override void FinishedDialogue()
    {
        if (_plotProgress == 0)
        {
            ScreenManager.Worlds["SpawnEntrance"]
                .AddNPC(new Robber(ScreenManager, SpriteBatch, ScreenManager.Worlds["SpawnEntrance"]));
        }
        else if (_plotProgress == 1)
        {
            ScreenManager.Worlds["Cabin1"]
                .AddNPC(new Chenny(ScreenManager, SpriteBatch, ScreenManager.Worlds["Cabin1"]));
            ScreenManager.Worlds["Cabin1"].AddNPC(new Pav(ScreenManager, SpriteBatch, ScreenManager.Worlds["Cabin1"]));
        }
        else if (_plotProgress == 2)
        {
            ScreenManager.Worlds["FarmBend"].AddNPC(new Vorrow(ScreenManager,SpriteBatch,ScreenManager.Worlds["FarmBend"]));
        }
        else if (_plotProgress == 3)
        {
            ScreenManager.Worlds["CobbleRoad"].AddNPC(new Nav(ScreenManager,SpriteBatch,ScreenManager.Worlds["CobbleRoad"]));
            ScreenManager.Worlds["RoadEnd"].AddNPC(new Lan(ScreenManager, SpriteBatch, ScreenManager.Worlds["RoadEnd"]));
            ScreenManager.Worlds["RoadEnd"].AddNPC(new Shash(ScreenManager,SpriteBatch,ScreenManager.Worlds["RoadEnd"]));
        }
        else if (_plotProgress == 4)
        {
            // ScreenManager.Worlds["Hideout"].AddNPC(new Lain(ScreenManager,SpriteBatch,ScreenManager.Worlds["Hideout"]));
            // ScreenManager.Worlds["Cabin2"].AddNPC(new Matt(ScreenManager, SpriteBatch, ScreenManager.Worlds["Hideout"]));
            // ScreenManager.Worlds["Cabin2"].AddNPC(new Pyro(ScreenManager,SpriteBatch,ScreenManager.Worlds["Hideout"]));
        }
        else if (_plotProgress == 5)
        {
            Player.SetDrawn(true);
        }

        _plotProgress++;
    }

    public override void AfterDeath()
    {
        ScreenManager.Worlds["SpawnEntrance"].AddNPC(new Raaj(ScreenManager,SpriteBatch,ScreenManager.Worlds["SpawnEntrance"]));
        Player.SetTexture(Textures.General.MouthedJay);
    }
}