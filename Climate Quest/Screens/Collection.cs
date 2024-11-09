using System;
using System.Collections.Generic;
using ClimateQuest.GameTextures;
using ClimateQuest.Screens.WorldScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ClimateQuest.Screens;

public class Collection : TextPopup
{
    private double _startTime;
    private bool _showPopup;
    private List<String> ClimateActions = new List<string>();
    private bool _newPending;
    private Player _player;
    private TextPopup _skillLabel;
    private String currentIcon;

    private static Dictionary<String, Texture2D> _iconTextures = new Dictionary<String, Texture2D>()
    {
        { "Composting", Textures.Icons.Composting },
        { "Recycling", Textures.Icons.Recycling },
        { "Efficiency", Textures.Icons.Energy },
        {"Voting",Textures.Icons.Voting},
        {"Transportation",Textures.Icons.Transportation}
    };
    private static Dictionary<String,Color> _iconColors = new Dictionary<String,Color>()
    {
        { "Composting", Color.DarkOrange },
        { "Recycling", Color.YellowGreen},
        { "Efficiency", Color.Aqua },
        {"Voting",Color.Silver},
        {"Transportation",Color.LimeGreen}
    };

    private List<String> actions = new List<string>() {"Composting","Voting","Efficiency","Transportation","Recycling"};

    public Collection(ScreenManager manager, SpriteBatch spriteBatch, Rectangle box, SpriteFont font, string text,
        Color color, float scale, int padding, Texture2D background,Player player) : base(manager, spriteBatch,box, font,text,color,scale,padding,background,false)
    {
        _newPending = false;
        _player = player;
        _skillLabel = new TextPopup(manager, spriteBatch, new Rectangle(box.X + 50, box.Y + 400, box.Width - 100, 300),Textures.General.Font,"TEST",Color.Red,1,50,Textures.General.Transparent,true);
    }

    public void NewUnlock(String action)
    {
        Textures.SoundEffects.DialogueFinished.Play();
        _newPending = true;
        ClimateActions.Add(action);
        SetText("CLIMATE ACTION UNLOCKED:");
        _skillLabel.SetText(action);
        _skillLabel.SetColor(_iconColors[action]);
        currentIcon = action;
    }

    public override void Update(GameTime gameTime)
    {
        if (Game1.IsKeyPressed(Keys.F))
        {
            _showPopup = false;
            _player.SetParalyzed(false);
        }
        if (_newPending)
        {
            _newPending = false;
            _showPopup = true;
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
            SpriteBatch.Draw(_iconTextures[currentIcon],new Rectangle(Box.X + 200,Box.Y + 250,200,200),Color.White);
        }

        for (var i = 0; i < actions.Count; i++)
        {
            if (ClimateActions.Contains(actions[i]))
            {
                SpriteBatch.Draw(_iconTextures[actions[i]], new Rectangle(40 + i * 90, 800, 70, 70), Color.White);
            }
        }
    }
}