using System;
using System.Text;
using ClimateQuest.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.Screens;

public class TextPopup: Popup
{
    protected string Text;
    protected string WrappedText;
    protected readonly SpriteFont Font;
    protected Color Color;
    protected float Scale;
    protected int Padding;
    protected Texture2D Background;
    protected bool DisplayArrow;
    private bool _centered;
    
    public TextPopup(ScreenManager manager,SpriteBatch spriteBatch,Rectangle box,SpriteFont font,string text,Color color,float scale,int padding,Texture2D background,bool centered) : base(manager,spriteBatch,box)
    {
        DisplayArrow = false;
        Text = text;
        Font = font;
        Color = color;
        Scale = scale;
        Padding = padding;
        Background = background;
        _centered = centered;
        UpdateWrapped();
    }

    public void SetDisplayArrow(bool display)
    {
        DisplayArrow = display;
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Draw(Background,Box,Color.White);
        // SpriteBatch.Draw(Textures.General.SolidColor,new Rectangle(Box.X + Padding,Box.Y + Padding,Box.Width - 2 * Padding,Box.Height - 2 * Padding),Color.Yellow);
        int offset = 0;
        if (_centered)
        {
            offset = (int) ((Box.Width - Padding * 2) - Font.MeasureString(Text).X * Scale) / 2;
        }
        SpriteBatch.DrawString(Font, WrappedText, new Vector2(Box.X + Padding + offset, Box.Y + Padding), Color, 0,
                         new Vector2(0, 0), Scale, SpriteEffects.None, 0);

        if (DisplayArrow)
        {
            SpriteBatch.Draw(Textures.General.NextArrow, new Rectangle(910, 910, 32, 32), Color.White);
        }
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public void SetPosition(int x, int y)
    {
        Box.X = x;
        Box.Y = y;
    }

    public void SetColor(Color color)
    {
        Color = color;
    }

    public void SetText(string text)
    {
        Text = text;
        UpdateWrapped();
    }
    
    private void UpdateWrapped()
    {
        var width = Box.Width - Padding * 2;
        if (_centered)
        {
            
        }
        try
        {
            if (Font.MeasureString(Text).X * Scale < width)
            {
                WrappedText = Text;
            }
        }
        catch
        {
            // Console.WriteLine(Text);
        }

        var lines = Text.Split('\n');
        var wrappedLines = new StringBuilder();
        foreach (var line in lines)
        {
            var words = line.Split(' ');
            var wrappedText = new StringBuilder();
            var lineWidth = 0f;
            var spaceWidth = Font.MeasureString(" ").X * Scale;
            foreach (var t in words)
            {
                var size = Font.MeasureString(t) * Scale;
                if (lineWidth + size.X < width)
                {
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    wrappedText.Append('\n');
                    lineWidth = size.X + spaceWidth;
                }

                wrappedText.Append(t);
                wrappedText.Append(' ');
            }

            wrappedLines.Append(wrappedText);
            wrappedLines.Append('\n');
        }
        
        WrappedText = wrappedLines.ToString();
    }
}