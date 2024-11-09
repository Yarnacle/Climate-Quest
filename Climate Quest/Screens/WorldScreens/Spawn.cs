using System.Collections.Generic;
using System.Transactions;
using ClimateQuest.GameTextures;
using ClimateQuest.Screens.WorldScreens.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens.WorldScreens;

public class Spawn : World
{

    public Spawn(ScreenManager manager, SpriteBatch spriteBatch) : base(manager, spriteBatch,
        (Texture2D)Textures.PixelMaps.Spawn, new Dictionary<Point, string>()
        {
            { new Point(-1, 4), "SpawnEntrance" },
            { new Point(-1, 5), "SpawnEntrance" }
        },false)
    {
        NPCs.Add(Color.Maroon,new MayorJay(ScreenManager,spriteBatch,this));
    }
    
    public override void Draw(GameTime gameTime)
    {
    }

    // public override void Update(GameTime gameTime)
    // {
    //     base.Update(gameTime);
    // }
}