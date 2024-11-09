using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text.Encodings.Web;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ClimateQuest.Screens.WorldScreens.NPCs;

public abstract class Npc: Tile
{
    protected List<Point> Path;
    protected World World;
    protected int Destination;
    protected enum State
    {
        Before,During,After
    }

    protected bool Dead;
    private int _deathFrames;
    
    protected TextPopup DialogueBox;

    protected Player Player;
    protected int DialogueIndex;
    protected List<Tuple<Color,string>> Dialogue;
    protected State DialogueState;
    protected List<Tuple<Color, string>> LastWords;
    private bool _sayingLastWords;
    
    protected Npc(ScreenManager manager,SpriteBatch spriteBatch,Color color,World world,List<Tuple<Color,string>> dialogue,Point gridPosition,List<Point> path,List<Tuple<Color,string>> lastWords): base(manager,spriteBatch,gridPosition,color)
    {
        _sayingLastWords = false;
        LastWords = lastWords;
        Dead = false;
        _deathFrames = -1;
        World = world;
        Destination = -1;
        Path = path;
        DialogueState = State.Before;
        Dialogue = dialogue;
        DialogueIndex = 0;
        // TextColor = textColor;
        DialogueBox = new TextPopup(manager, spriteBatch, new Rectangle(0, 750, 1000, 250), Textures.General.Font,
            Dialogue == null ? "ERROR":Dialogue[0].Item2, Dialogue == null ? Color.Red:Dialogue[0].Item1, .5f, 60, Textures.General.DialogueBox,false);
    }

    public void SetGridPosition(Point gridPosition)
    {
        GridPosition = gridPosition;
        Box.X = GridPosition.X * 100;
        Box.Y = GridPosition.Y * 100;
    }
    
    public void StartPath()
    {
        if (Dead)
        {
            return;
        }
        Destination = 0;
    }

    public void SkipPath()
    {
        if (Path == null)
        {
            return;
        }

        if (Destination == -1)
        {
            return;
        }
        GridPosition = Path[Path.Count - 1];
        Box.X = GridPosition.X * 100;
        Box.Y = GridPosition.Y * 100;
        Destination = Path.Count;
    }

    public void SkipDeath()
    {
        _deathFrames = 41;
    }

    public void SetPlayer(Player player)
    {
        Player = player;
    }

    public void NewDialogue(List<Tuple<Color,string>> newDialogue)
    {
        Dialogue = newDialogue;
        DialogueState = State.Before;
        DialogueIndex = 0;
    }

    public bool IsDead()
    {
        return Dead;
    }

    public virtual void InitiateDialogue()
    {
        if (Dead)
        {
            return;
        }
        if (DialogueState == State.After)
        {
            return;
        }

        if (Dialogue == null)
        {
            return;
        }
        DialogueBox.SetColor(Dialogue[DialogueIndex].Item1);
        DialogueBox.SetText(Dialogue[DialogueIndex].Item2);
        Player.SetParalyzed(true);
        DialogueState = State.During;
        if (Dialogue[DialogueIndex].Item1 == Color.White)
        {
            Textures.SoundEffects.PlayerDialogue.Play();
        }
        else
        {
            Textures.SoundEffects.NPCDialogue.Play();
        }
    }
    public virtual void NextDialogue()
    {
        if (DialogueIndex == Dialogue.Count - 1)
        {
            DialogueState = State.After;
            Player.SetParalyzed(false);
            if (_sayingLastWords)
            {
                LastWords = null;
                Die();
            }

            FinishedDialogue();
            return;
        }
        DialogueIndex++;
        DialogueBox.SetColor(Dialogue[DialogueIndex].Item1);
        DialogueBox.SetText(Dialogue[DialogueIndex].Item2);
        if (Dialogue[DialogueIndex].Item1 == Color.White)
        {
            Textures.SoundEffects.PlayerDialogue.Play();
        }
        else
        {
            Textures.SoundEffects.NPCDialogue.Play();
        }
    }

    public virtual void FinishedDialogue()
    {
        // Textures.SoundEffects.DialogueFinished.Play();
    }

    public virtual void Die()
    {
        if (Dead)
        {
            return;
        }

        if (LastWords != null)
        {
            NewDialogue(LastWords);
            InitiateDialogue();
            _sayingLastWords = true;
            return;
        }
        
        Dead = true;
        _deathFrames = 0;
        DialogueState = State.After;
        ScreenManager.AddKill();

        AfterDeath();
    }

    public virtual void AfterDeath()
    {
        
    }

    public void ChangeWorld(World world,Point position,List<Point> newPath,List<Tuple<Color,string>> newDialogue)
    {
        GridPosition = position;
        Box.X = GridPosition.X * 100;
        Box.Y = GridPosition.Y * 100;
        World = world;
        NewDialogue(newDialogue);
        world.AddNPC(this);
        NewPath(newPath);
    }

    public void NewPath(List<Point> newPath)
    {
        Path = newPath;
        Destination = -1;
    }

    public Point GetDestination()
    {
        if (Destination < 0 || Destination == Path.Count)
        {
            return GridPosition;
            
        }
        if (Path[Destination].Y > GridPosition.Y)
        {
            return new Point(GridPosition.X, GridPosition.Y + 1);
        }
        
        if (Path[Destination].Y < GridPosition.Y)
        {
            return new Point(GridPosition.X, GridPosition.Y - 1);
        }
        
        if (Path[Destination].X > GridPosition.X)
        {
            return new Point(GridPosition.X + 1, GridPosition.Y);
        }
        
        if (Path[Destination].X < GridPosition.X)
        {
            return new Point(GridPosition.X - 1, GridPosition.Y);
        }
        
        return GridPosition;
    }

    public override void Draw(GameTime gameTime)
    {
        // SpriteBatch.Draw(Textures.General.SolidColor,new Rectangle(GridPosition.X * 100,GridPosition.Y * 100,100,100),Color.White);
        if (_deathFrames > 40)
        {
            SpriteBatch.Draw(Textures.NPCs.Death3,Box,Color.White);
        }
        else if (_deathFrames > 30)
        {
            SpriteBatch.Draw(Textures.NPCs.Death3,Box,Color.White);
            SpriteBatch.Draw(Textures.Tiles[Color],new Rectangle(Box.X,Box.Y + 45,Box.Width,Box.Height - 90),Color.White);
        }
        else if (_deathFrames > 20)
        {
            SpriteBatch.Draw(Textures.NPCs.Death2,Box,Color.White);
            SpriteBatch.Draw(Textures.Tiles[Color],new Rectangle(Box.X,Box.Y + 40,Box.Width,Box.Height - 80),Color.White);
        }
        else if (_deathFrames > 10)
        {
            SpriteBatch.Draw(Textures.NPCs.Death1,Box,Color.White);
            SpriteBatch.Draw(Textures.Tiles[Color],new Rectangle(Box.X,Box.Y + 30,Box.Width,Box.Height - 60),Color.White);
        }
        else if (_deathFrames > -1)
        {
            SpriteBatch.Draw(Textures.Tiles[Color],new Rectangle(Box.X,Box.Y + 10,Box.Width,Box.Height - 20),Color.White);
        }

        if (Dead)
        {
            return;
        }
        base.Draw(gameTime);
    }

    public override void Update(GameTime gameTime)
    {
        if (DialogueState == State.During)
        {
            if (Game1.IsKeyPressed(Keys.F))
            {
                NextDialogue();
            }

            if (ScreenManager.GetForeground()[ScreenManager.GetForeground().Count - 1] != DialogueBox)
            {
                ScreenManager.Add(DialogueBox);
            }
            if (DialogueIndex < Dialogue.Count - 1)
            {
                DialogueBox.SetDisplayArrow(true);
            }
            else
            {
                DialogueBox.SetDisplayArrow(false);
            }
        }
        else
        {
            if (ScreenManager.GetForeground()[ScreenManager.GetForeground().Count - 1] == DialogueBox)
            {
                ScreenManager.ClearTop();
            }
        }
        
        if (Dead || _sayingLastWords)
        {
            if (GridPosition != GetDestination())
            {
                if (GetDestination().X * 100 > Box.X)
                {
                    Box.X += 5;
                }
                else if (GetDestination().Y * 100 > Box.Y)
                {
                    Box.Y += 5;
                }
                else if (GetDestination().X * 100 < Box.X)
                {
                    Box.X -= 5;
                }
                else if (GetDestination().Y * 100 < Box.Y)
                {
                    Box.Y -= 5;
                }

                if (Box.X == GetDestination().X * 100 && Box.Y == GetDestination().Y * 100)
                {
                    GridPosition = GetDestination();
                    Destination = -1;
                    // Console.WriteLine("No more remains momentum");
                }
            }
            _deathFrames++;
            return;
        }

        if (Path == null)
        {
            return;
        }
        if (Destination > -1 && Destination < Path.Count)
        {
            if (Box.Y % 100 == 0 && Box.X % 100 == 0)
            {
                GridPosition = new Point(Box.X / 100, Box.Y / 100);
            }
            if (Path[Destination].Y * 100 == Box.Y && Path[Destination].X * 100 == Box.X)
            {
                Destination++;
            }
            else if (Path[Destination].Y > GridPosition.Y)
            {
                Box.Y += 5;
            }
            else if (Path[Destination].X > GridPosition.X)
            {
                Box.X += 5;
            }
            else if (Path[Destination].X < GridPosition.X)
            {
                Box.X -= 5;
            }
            else
            {
                Box.Y -= 5;
            }
        }
    }
}