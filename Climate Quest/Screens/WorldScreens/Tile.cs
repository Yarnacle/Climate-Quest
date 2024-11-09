using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens;

public class Tile: Popup
{
    protected Color Color;
    protected Point GridPosition;
    
    public Tile(ScreenManager manager,SpriteBatch spriteBatch,Point gridPosition,Color color): base(manager,spriteBatch,new Rectangle(gridPosition.X * 100,gridPosition.Y * 100,100,100))
    {
        Color = color;
        GridPosition = gridPosition;
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Draw(Textures.Tiles[Color],Box,Color.White);
    }

    public void SetType(Color color)
    {
        Color = color;
    }

    public Point GetGridPosition()
    {
        return GridPosition;
    }

    public Color GetColor()
    {
        return Color;
    }
}