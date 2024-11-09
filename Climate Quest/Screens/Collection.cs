using System;
using System.Collections.Generic;
using ClimateQuest.GameTextures;
using ClimateQuest.Screens.WorldScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens;

public class Collection : TextPopup
{
    private double _startTime;
    private bool _showPopup;
    private List<String> ClimateActions = new List<string>();
    private bool _newPending;
    private Player _player;
    private TextPopup _skillLabel;

    public Collection(ScreenManager manager, SpriteBatch spriteBatch, Rectangle box, SpriteFont font, string text,
        Color color, float scale, int padding, Texture2D background,Player player) : base(manager, spriteBatch,box, font,text,color,scale,padding,background,false)
    {
        _newPending = false;
        _player = player;
        _skillLabel = new TextPopup(manager, spriteBatch, new Rectangle(box.X + 50, box.Y + 400, box.Width - 100, 300),Textures.General.Font,"TEST",Color.Red,1,50,Textures.General.Transparent,true);
    }

    public void NewUnlock(String action)
    {
        _newPending = false;
        _showPopup = true;
        ClimateActions.Add(action);
        SetText("CLIMATE ACTION UNLOCKED:");
        _skillLabel.SetText(action);
    }

    public override void Update(GameTime gameTime)
    {
        if (_newPending)
        {
            _newPending = false;
            _showPopup = true;
            _startTime = gameTime.TotalGameTime.TotalMilliseconds;
        }
        if ((gameTime.TotalGameTime.TotalMilliseconds - _startTime) / 1000 > 5)
        {
            _showPopup = false;
            _player.SetParalyzed(false);
        }
    }

    public override void Draw(GameTime gameTime)
    {
        if (_showPopup)
        {
            _player.SetParalyzed(true);
            SpriteBatch.Draw(Background,Box,Color.White);
            base.Draw(gameTime);
            _skillLabel.Draw(gameTime);
        }
    }
}