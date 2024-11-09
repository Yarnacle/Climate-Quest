using System;
using System.Collections.Generic;
using ClimateQuest.Screens.WorldScreens.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens;

public abstract class World: FullScreen
{
    protected bool IsRunning;
    private bool _drawWeapon;
    protected Dictionary<Color,Npc> NPCs;
    
    protected Dictionary<Point,string> Exits;
    public static readonly List<Color> BarrierColors = new() {Color.Red,Color.Brown,Color.SlateGray};
    public static readonly List<Color> VoidColors = new() { Color.Blue };

    protected readonly Tile[][] Tiles;

    protected Player Player;

    protected World(ScreenManager manager, SpriteBatch spriteBatch, Texture2D background,Dictionary<Point,string> exits,bool drawWeapon) : base(manager,spriteBatch)
    {
        _drawWeapon = drawWeapon;
        NPCs = new Dictionary<Color, Npc>();
        Player = null;
        Exits = exits;
        var pixelMap = new Color[background.Width * background.Height];
        background.GetData(pixelMap);
        Tiles = new Tile[10][];
        for (var y = 0; y < 10; y++)
        {
            Tiles[y] = new Tile[10];
            for (var x = 0; x < 10; x++)
            {
                var color = pixelMap[y * 10 + x];
                var tile = new Tile(ScreenManager, SpriteBatch, new Point(x,y),color);
                Tiles[y][x] = tile;
            }
        }

        IsRunning = false;
    }

    public virtual void Enter(Player player)
    {
        for (var y = 0; y < 10; y++)
        {
            for (var x = 0; x < 10; x++)
            {
                ScreenManager.Add(Tiles[y][x]);
            }
        }
        
        Player = player;
        Player.SetWorld(this);
        
        foreach (var npc in NPCs.Values)
        {
            // Console.WriteLine("Added " + npc);
            npc.SetPlayer(player);
            ScreenManager.Add(npc); 
        }
        
        ScreenManager.Add(Player);
        IsRunning = true;

        Player.SetDrawn(_drawWeapon);
    }

    protected virtual void Exit(World world)
    {
        foreach (var npc in NPCs.Values)
        {
            npc.SetPlayer(null);
            npc.SkipPath();
            if (npc.IsDead())
            {
                npc.SkipDeath();
            }
        }
        ScreenManager.SetBackgroud(world);
        ScreenManager.ClearForeground();
        IsRunning = false;
        world.Enter(Player);
        Player = null;
    }

    public Dictionary<Point,string> GetExits()
    {
        return Exits;
    }

    public void AddNPC(Npc npc)
    {
        NPCs.Add(npc.GetColor(),npc);
    }

    public void RemoveNPC(Color color)
    {

        for (var i = ScreenManager.GetForeground().Count - 1; i >= 0; i--)
        {
            if (ScreenManager.GetForeground()[i] == NPCs[color])
            {
                ScreenManager.RemoveAt(i);
                break;
            }
        }
        NPCs.Remove(color);
    }

    public override void Update(GameTime gameTime)
    {
        if (!IsRunning)
        {
            return;
        }
    }

    public override void Draw(GameTime gameTime)
    {
        
    }

    public bool CheckTile(Point gridPosition)
    {
        if (gridPosition.Y > 9 || gridPosition.Y < 0 || gridPosition.X > 9 || gridPosition.X < 0)
        {
            if (Exits.ContainsKey(gridPosition))
            {
                Exit(ScreenManager.Worlds[Exits[gridPosition]]);
                return true;
            }
            return false;
        }

        if (BarrierColors.Contains(Tiles[gridPosition.Y][gridPosition.X].GetColor()) || VoidColors.Contains(Tiles[gridPosition.Y][gridPosition.X].GetColor()))
        {
            return false;
        }

        foreach (var npc in NPCs.Values)
        {
            if (npc.GetGridPosition() == gridPosition)
            {
                npc.InitiateDialogue();
                return false;
            }
            if ((gridPosition == npc.GetDestination() || Player.GetGridPosition() == npc.GetDestination()) && npc.GetColor() != Color.Gold)
            {
                // Console.WriteLine("NPC Collision blocked");
                return false;
            }
        }

        return true;
    }

    public Tile[][] GetTiles()
    {
        return Tiles;
    }

    public Dictionary<Color,Npc> GetNPCs()
    {
        return NPCs;
    }
}