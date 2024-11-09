using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens;

public abstract class Popup: Screen
{
    protected Rectangle Box;
    protected Popup(ScreenManager manager,SpriteBatch spriteBatch,Rectangle box): base(manager,spriteBatch)
    {
        Box = box;
    }

    public Rectangle GetBox()
    {
        return Box;
    }
}