using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ClimateQuest.GameTextures;

public static class Textures
{
    private static GraphicsDevice _graphicsDevice;

    public static readonly Dictionary<Color,Texture2D> Tiles = new();
    
    // Directories
    public static readonly dynamic HomeScreen = new ExpandoObject();
    public static readonly dynamic General = new ExpandoObject();
    public static readonly dynamic PixelMaps = new ExpandoObject();
    public static readonly dynamic MaterialTiles = new ExpandoObject();
    public static readonly dynamic NPCs = new ExpandoObject();
    public static readonly dynamic Icons = new ExpandoObject();
    public static readonly dynamic SoundEffects = new ExpandoObject();
    
    public static void Load(GraphicsDevice graphicsDevice,ContentManager content)
    {
        _graphicsDevice = graphicsDevice;
        
        // Textures
        General.SolidColor = LoadTile("General/SolidColor.png",Color.White);
        General.Transparent = LoadTile("General/Transparent.png", Color.Transparent);
        General.ClearScreen = Load("General/ClearScreen.png");
        General.Font = LoadFont(content,"PixelFont");
        General.Lan = LoadTile("HomeScreen/Lan.png",Color.Red);
        
        General.SheriffJay = LoadTile("General/SheriffJay.png", Color.Gray);
        General.DestinationShadow = LoadTile("General/DestinationShadow.png", Color.LightGray);
        General.Gun = Load("General/Gun.png");
        General.Bullet = Load("General/Bullet.png");
        General.Vignette = Load("General/Vignette.png");
        General.Boom1 = Load("General/Boom1.png");
        General.Boom2 = Load("General/Boom2.png");
        General.DialogueBox = Load("General/DialogueBox.png");
        General.NextArrow = Load("General/NextArrow.png");
        General.EvilEyes = Load("General/EvilEyes.png");
        General.MouthedJay = LoadTile("General/MouthedSheriffJay.png", Color.Gray);
        General.UnlockSplash = Load("General/SplashTextBox.png");

        PixelMaps.Spawn = Load("PixelMaps/Spawn.png");
        PixelMaps.SpawnEntrance = Load("PixelMaps/SpawnEntrance.png");
        PixelMaps.PathToHouse = Load("PixelMaps/PathToHouse.png");
        PixelMaps.Cabin1 = Load("PixelMaps/Cabin1.png");
        PixelMaps.Cabin2 = Load("PixelMaps/Cabin2.png");
        PixelMaps.FarmRoad = Load("PixelMaps/FarmRoad.png");
        PixelMaps.FarmBend = Load("PixelMaps/FarmBend.png");
        PixelMaps.CobbleRoad = Load("PixelMaps/CobbleRoad.png");
        PixelMaps.RoadEnd = Load("PixelMaps/RoadEnd.png");
        PixelMaps.Hideout = Load("PixelMaps/Hideout.png");
        
        HomeScreen.Background = Load("HomeScreen/Background.png");

        MaterialTiles.WoodPlank = LoadTile("MaterialTiles/WoodPlank.png",Color.Orange);
        MaterialTiles.Cobblestone = LoadTile("MaterialTiles/Cobblestone.png",Color.DarkGray);
        MaterialTiles.Dirt = LoadTile("MaterialTiles/Dirt.png", Color.RosyBrown);
        MaterialTiles.Bark = LoadTile("MaterialTiles/Bark.png", Color.Brown);
        MaterialTiles.Farmland = LoadTile("MaterialTiles/Farmland.png", Color.GreenYellow);
        MaterialTiles.Grass = LoadTile("MaterialTiles/Grass.png", Color.Green);
        MaterialTiles.Bike = LoadTile("MaterialTiles/Bike.png", Color.LawnGreen);
        MaterialTiles.WhiteTile = LoadTile("MaterialTiles/WhiteTile.png", Color.WhiteSmoke);
        MaterialTiles.Water = LoadTile("MaterialTiles/Water.png", Color.Blue);
        MaterialTiles.Wall = LoadTile("MaterialTiles/Wall.png", Color.SlateGray);
        MaterialTiles.SecretDoor = LoadTile("MaterialTiles/SecretDoor.png", Color.Gold);
        MaterialTiles.Rubble = LoadTile("MaterialTiles/rubble.png", Color.Gray);
        MaterialTiles.Composter = LoadTile("MaterialTiles/Composter.png", Color.Olive);
        MaterialTiles.AC = LoadTile("MaterialTiles/GoodAirConditioner.png", Color.DarkOliveGreen);
        MaterialTiles.RecyclingBin = LoadTile("MaterialTiles/recycling.png", Color.Ivory);

        NPCs.Death1 = LoadTile("NPCs/Death1.png", new Color(150,150,150));
        NPCs.Death2 = LoadTile("NPCs/Death2.png", new Color(100,100,100));
        NPCs.Death3 = LoadTile("NPCs/Death3.png", new Color(50,50,50));
        NPCs.MayorJay = LoadTile("NPCs/MayorJay.png", Color.Maroon);
        NPCs.GangLeader = LoadTile("NPCs/Lain.png", Color.Yellow);
        NPCs.Robber = LoadTile("NPCs/Robber.png", Color.Purple);
        NPCs.Chenny = LoadTile("NPCs/Chenny.png", Color.LightGreen);
        NPCs.Pav = LoadTile("NPCs/Pav.png", Color.DarkOrange);
        NPCs.Vorrow = LoadTile("NPCs/Vorrow.png", Color.DarkGreen);
        NPCs.Nav = LoadTile("NPCs/Nav.png", Color.Pink);
        NPCs.Lan = LoadTile("NPCs/Lan.png", Color.Beige);
        NPCs.Shash = LoadTile("NPCs/Shash.png", Color.LightBlue);
        NPCs.Lain = LoadTile("NPCs/Lain.png", Color.Wheat);
        NPCs.Matt = LoadTile("NPCs/Matt.png", Color.Tomato);
        NPCs.Pyro = LoadTile("NPCs/Pyro.png", Color.Honeydew);
        NPCs.Raaj = LoadTile("NPCs/Raaj.png", Color.DarkBlue);
        NPCs.Biker = LoadTile("NPCs/Biker.png", Color.CadetBlue);
        
        SoundEffects.DialogueFinished = LoadSoundEffect("Sounds/DialogueFinished.wav");
        SoundEffects.StartGame = LoadSoundEffect("Sounds/StartGame.wav");
        SoundEffects.NPCDialogue = LoadSoundEffect("Sounds/NPCDialogue.wav");
        SoundEffects.PlayerDialogue = LoadSoundEffect("Sounds/PlayerDialogue.wav");
    }

    private static Texture2D Load(string path)
    {
        var fileStream = new FileStream("Content/Textures/" + path, FileMode.Open);
        var texture = Texture2D.FromStream(_graphicsDevice,fileStream);
        fileStream.Close();
        return texture;
    }

    private static Texture2D LoadTile(string path, Color tileColor)
    {
         var texture = Load(path);
         Tiles[tileColor] = texture;
         return texture;
    }

    private static SpriteFont LoadFont(ContentManager content,string path)
    {
        return content.Load<SpriteFont>(path);
    }

    private static SoundEffect LoadSoundEffect(string path)
    {
        var fileStream = new FileStream("Content/" + path, FileMode.Open);
        var texture = SoundEffect.FromStream(fileStream);
        fileStream.Close();
        return texture;
    }
}