using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens;

public class Boom
{
    private int _frames;
    private Rectangle _box;
    private SpriteBatch _spriteBatch;
    private const int Width = 25;
    private bool _done;
    
    public Boom(SpriteBatch spriteBatch,Point position)
    {
        _done = false;
        _spriteBatch = spriteBatch;
        _frames = 0;
        _box = new Rectangle(position.X - Width / 2,position.Y - Width / 2,Width,Width);
    }

    public void Draw(GameTime gameTime)
    {
        if (_frames > 10)
        {
            _done = true;
        }
        if (_frames > 5)
        {
            _spriteBatch.Draw(Textures.General.Boom2,_box,Color.White);
        }
        else
        {
            _spriteBatch.Draw(Textures.General.Boom1,_box,Color.White);
        }
        _frames++;
    }

    public bool IsDone()
    {
        return _done;
    }
}