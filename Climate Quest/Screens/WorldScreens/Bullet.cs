using System;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens;

public class Bullet
{
    private SpriteBatch _spriteBatch;
    private int _velocity;
    private Rectangle _box;


    public Bullet(SpriteBatch spriteBatch,int velocity,Rectangle box)
    {
        _spriteBatch = spriteBatch;
        _velocity = velocity;
        _box = box;
    }

    public Point GetPosition()
    {
        if (_velocity < 0)
        {
            return new Point(_box.X + 25, _box.Y + 113);
        }
        return new Point(_box.X + 167,_box.Y + 113); // magic numbers based on texture resolution to tile width ratio DO NOT TOUCH
    }

    public void Update(GameTime gameTime)
    {
        _box.X += _velocity;
    }

    public void Draw(GameTime gameTime)
    {
        _spriteBatch.Draw(Textures.General.Bullet,_box,new Rectangle(0,0,Textures.General.Bullet.Width,Textures.General.Bullet.Height),Color.Yellow,0,new Vector2(0,0),_velocity < 0 ? SpriteEffects.FlipHorizontally:SpriteEffects.None,0);
    }
}