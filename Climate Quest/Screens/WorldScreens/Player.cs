using System;
using System.Collections.Generic;
using System.IO;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ClimateQuest.Screens.WorldScreens;

public class Player: Tile
{
    public enum Direction {None,Up,Down,Left,Right}
    
    private readonly SpriteBatch _spriteBatch;
    private World _world;
    
    // private const float QuarterRotation = (float) Math.PI / 2;

    private Point _destination;
    private Direction _moveDirection;
    
    private static Texture2D _texture;

    private bool _horizontalFlip;
    private bool _paralyzed;
    private bool _drawn;
    private readonly List<Bullet> _bullets;
    private readonly List<Boom> _booms;
    
    private const int Speed = 10;
    private const bool GunOverride = false;

    public Collection Collection;
    
    public Player(ScreenManager manager,SpriteBatch spriteBatch,Texture2D texture, Point gridPosition): base(manager,spriteBatch,gridPosition,Color.Gray)
    {
        _bullets = new List<Bullet>();
        _booms = new List<Boom>();
        _paralyzed = false;
        _drawn = false;
        _moveDirection = Direction.None;
        _spriteBatch = spriteBatch;
        _destination = GridPosition;
        _texture = texture;
        Collection = new Collection(manager, spriteBatch, new Rectangle(200, 200, 600, 600), Textures.General.Font, "",
            Color.White, 1, 50, Textures.General.UnlockSplash,this);
    }

    public void SetTexture(Texture2D texture)
    {
        _texture = texture;
    }

    public void SetParalyzed(bool paralyzed)
    {
        _paralyzed = paralyzed;
        if (_paralyzed)
        {
            _drawn = false;
        }
    }

    public void SetDrawn(bool drawn)
    {
        _drawn = drawn;
    }
    public void SetWorld(World world)
    {
        _bullets.Clear();
        _booms.Clear();
        _world = world;
        switch (_moveDirection)
        {
            case Direction.Down:
                GridPosition.Y = -1;
                _destination.Y = 0;
                break;
            case Direction.Up:
                GridPosition.Y = 10;
                _destination.Y = 9;
                break;
            case Direction.Left:
                GridPosition.X = 10;
                _destination.X = 9;
                break;
            case Direction.Right:
                GridPosition.X = -1;
                _destination.X = 0;
                break;
        }
        Box.X = GridPosition.X * 100;
        Box.Y = GridPosition.Y * 100;
    }
    
    public override void Update(GameTime gameTime)
    {
        Collection.Update(gameTime);
        for (var i = _bullets.Count - 1; i >= 0; i--)
        {
            _bullets[i].Update(gameTime);
            var bulletPosition = _bullets[i].GetPosition();
            if (bulletPosition.X > 1000 || bulletPosition.X < 0 || bulletPosition.Y > 1000 || bulletPosition.Y < 0)
            {
                _bullets.RemoveAt(i);
                _booms.Add(new Boom(SpriteBatch,bulletPosition));
            }

            var tiles = _world.GetTiles(); 
            foreach (var row in tiles)
            {
                foreach (var tile in row)
                {
                    if (World.BarrierColors.Contains(tile.GetColor()) && tile.GetBox().Contains(bulletPosition))
                    {
                        _bullets.RemoveAt(i);
                        _booms.Add(new Boom(SpriteBatch,bulletPosition));
                    }
                }
            }

            var npcs = _world.GetNPCs();
            foreach (var npc in npcs.Values)
            {
                if (npc.GetBox().Contains(bulletPosition) && !npc.IsDead())
                {
                    _bullets.RemoveAt(i);
                    _booms.Add(new Boom(SpriteBatch,bulletPosition));
                    npc.Die();
                }
            }
        }
        
        if ((_drawn && !_paralyzed) || GunOverride)
        {
            if (Game1.IsKeyPressed(Keys.Space))
            {
                _bullets.Add(new Bullet(SpriteBatch,_horizontalFlip ? -10:10,new Rectangle(Box.X - 50,Box.Y - 50,200,200)));
            }
        }
        
        if (_moveDirection != Direction.None)
        {
            switch (_moveDirection)
            {
                case Direction.Down:
                    Box.Y += Speed;
                    break;
                case Direction.Up:
                    Box.Y -= Speed;
                    break;
                case Direction.Right:
                    Box.X += Speed;
                    break;
                case Direction.Left:
                    Box.X -= Speed;
                    break;
            }
            
            if (Box.X == _destination.X * 100 && Box.Y == _destination.Y * 100)
            {
                GridPosition = _destination;
                _moveDirection = Direction.None;
            }

            return;
        }
        
        if (_paralyzed)
        {
            // Console.WriteLine(gameTime.TotalGameTime + ": Paralyzed");
            return;
        }
        
        if (Game1.IsKeyDown(Keys.W) || Game1.IsKeyDown(Keys.S))
        {
            if (Game1.IsKeyDown(Keys.W))
            {
                _destination.Y--;
            }
            else
            {
                _destination.Y++;
            }
        }
        else if (Game1.IsKeyDown(Keys.D) || Game1.IsKeyDown(Keys.A))
        {
            if (Game1.IsKeyDown(Keys.A))
            {
                _destination.X--;
            }
            else
            {
                _destination.X++;
            }
        }
        if (_destination.X < GridPosition.X)
        {
            _moveDirection = Direction.Left;
            _horizontalFlip = true;
        }
        else if (_destination.X > GridPosition.X)
        {
            _moveDirection = Direction.Right;
            _horizontalFlip = false;
        }
        else if (_destination.Y < GridPosition.Y)
        {
            _moveDirection = Direction.Up;
        }
        else if (_destination.Y > GridPosition.Y)
        {
            _moveDirection = Direction.Down;
        }

        if (!_world.CheckTile(_destination))
        {
            _moveDirection = Direction.None;
            _destination = GridPosition;
        }
    }
    public override void Draw(GameTime gameTime)
    {
        // if (_destination != GridPosition)
        // {
        //     _spriteBatch.Draw(Textures.General.SolidColor,
        //         new Rectangle(_destination.X * 100, _destination.Y * 100, 100, 100), new Color(Color.Gray, .4f));
        // }
        
        _spriteBatch.Draw(Textures.General.DestinationShadow,new Rectangle(_destination.X * 100,_destination.Y * 100,100,100),new Rectangle(0,0,_texture.Width,_texture.Height),Color.Black, 0, new Vector2(0,0), _horizontalFlip ? SpriteEffects.FlipHorizontally:SpriteEffects.None, 0);
        _spriteBatch.Draw(_texture, Box, new Rectangle(0, 0, _texture.Width,_texture.Height), Color.White, 0, new Vector2(0,0), _horizontalFlip ? SpriteEffects.FlipHorizontally:SpriteEffects.None, 0);
        _spriteBatch.Draw(Textures.General.EvilEyes,Box,new Rectangle(0,0,_texture.Width,_texture.Height),Color.White * ScreenManager.GetEvilPercent(),0,new Vector2(0,0),_horizontalFlip ? SpriteEffects.FlipHorizontally:SpriteEffects.None,0);
        Collection.Draw(gameTime);
        
    }
}