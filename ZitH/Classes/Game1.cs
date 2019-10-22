using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace ZitH
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Core core = new Core();

        public static MouseState mouse = Mouse.GetState();
        public static MouseState mouse2 = Mouse.GetState();

        public static KeyboardState Keyboardstate = Keyboard.GetState();
        public static KeyboardState Keyboardstate2 = Keyboard.GetState();     

        public static KeyboardState EscButtonState = Keyboard.GetState();
        public static KeyboardState EscButtonState2 = Keyboard.GetState();

        public static int scen = 1; 
        public static int menuScene = 0;
        public static int gameScene = 0;
        public static bool EscButton = false;
        public static bool exitGame = false;

        //public static string fullscreenon = "img/fullscreenon";
        //public static string fullscreenoff = "img/fullscreenoff";
        //public static string fullscreenURL = "img/fullscreenoff";

        public static bool isfullscreen = true;

        private Texture2D play, settings, exit, fullscreen, back, exittomm, exitfromgame, gameStart, //Buttons
            menuBg, gameBg, opaqueBg, //Backgrounds
            Boris, Maxim, Nadya, Nastya, Sasha, //Humans
            Boss, Dog, Spider, Zombie, //Enemies
            Ak47, Axe, Crowbow, Gas, Grenade, HP, Key, Knife, Medkit, Pistol, RPG, Shotgun, Wood, //Items
            Map; //Map
        private Vector2 position;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen = isfullscreen;
            graphics.ApplyChanges();
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Positions();
            Load();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (scen == 0 && EscButtonState.IsKeyDown(Keys.Escape) && EscButtonState2.IsKeyUp(Keys.Escape))
            {
                EscButton = true;
            }
            else { EscButton = false; }

            MouseUpdate();
            KeyboardUpdate();

            if (exitGame)
            {
                Exit();
            }

                if (Keyboardstate.IsKeyDown(Keys.W) && Keyboardstate2.IsKeyUp(Keys.W) || Keyboardstate.IsKeyDown(Keys.Up) && Keyboardstate2.IsKeyUp(Keys.Up))
                {
                    position.Y -= 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.A) && Keyboardstate2.IsKeyUp(Keys.A) || Keyboardstate.IsKeyDown(Keys.Left) && Keyboardstate2.IsKeyUp(Keys.Left))
                {
                    position.X -= 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.S) && Keyboardstate2.IsKeyUp(Keys.S) || Keyboardstate.IsKeyDown(Keys.Down) && Keyboardstate2.IsKeyUp(Keys.Down))
                {
                    position.Y += 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.D) && Keyboardstate2.IsKeyUp(Keys.D) || Keyboardstate.IsKeyDown(Keys.Right) && Keyboardstate2.IsKeyUp(Keys.Right))
                {
                    position.X += 52;
                }

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            switch (scen)
            {
                case 0:
                    DrawGame();
                    break;
                case 1:
                    DrawMenu();
                    break;
            }
        }

        private void Load()
        {
            play = Content.Load<Texture2D>("img/play");
            settings = Content.Load<Texture2D>("img/settings");
            exit = Content.Load<Texture2D>("img/exit");
            back = Content.Load<Texture2D>("img/back");
            gameStart = Content.Load<Texture2D>("img/GameStart");
            exittomm = Content.Load<Texture2D>("img/exittomm");
            exitfromgame = Content.Load<Texture2D>("img/exitfromgame");

            menuBg = Content.Load<Texture2D>("img/menuBg");
            gameBg = Content.Load<Texture2D>("img/gameBg");
            opaqueBg = Content.Load<Texture2D>("img/opaqueBg");

            Boris = Content.Load<Texture2D>("img/Boris");
            Maxim = Content.Load<Texture2D>("img/Maxim");
            Nadya = Content.Load<Texture2D>("img/Nadya");
            Nastya = Content.Load<Texture2D>("img/Nastya");
            Sasha = Content.Load<Texture2D>("img/Sasha");

            Boss = Content.Load<Texture2D>("img/Boss");
            Dog = Content.Load<Texture2D>("img/Dog");
            Spider = Content.Load<Texture2D>("img/Spider");
            Zombie = Content.Load<Texture2D>("img/Zombie");

            Ak47 = Content.Load<Texture2D>("img/Ak47");
            Axe = Content.Load<Texture2D>("img/Axe");
            Crowbow = Content.Load<Texture2D>("img/Crowbow");
            Gas = Content.Load<Texture2D>("img/Gas");
            Grenade = Content.Load<Texture2D>("img/Grenade");
            HP = Content.Load<Texture2D>("img/HP");
            Key = Content.Load<Texture2D>("img/Key");
            Knife = Content.Load<Texture2D>("img/Knife");
            Medkit = Content.Load<Texture2D>("img/Medkit");
            Pistol = Content.Load<Texture2D>("img/Pistol");
            RPG = Content.Load<Texture2D>("img/RPG");
            Shotgun = Content.Load<Texture2D>("img/Shotgun");
            Wood = Content.Load<Texture2D>("img/Wood");

            //fullscreen = Content.Load<Texture2D>(fullscreenURL);

            Map = Content.Load<Texture2D>("img/Map");
        }

        private void Positions()
        {
            position = new Vector2(1920 / 2 - 795 / 2 + 35 + 51, 1080 / 2 + 264);
        }

        void DrawMenu()
        {
            GraphicsDevice.Clear(Color.DarkGray);
            spriteBatch.Begin();
            spriteBatch.Draw(menuBg, new Vector2(0, 0), Color.White);
            switch (menuScene)
            {
                //Standard menu
                case 0:
                    spriteBatch.Draw(play, core.ui.graphics.playRec, Color.White);
                    spriteBatch.Draw(settings, core.ui.graphics.settingRec, Color.White);
                    spriteBatch.Draw(exit, core.ui.graphics.exitRec, Color.White);
                    core.ui.MenuButtons();
                    break;
                //Settings menu
                case 1:
                    //spriteBatch.Draw(fullscreen, core.ui.graphics.fullscreenRec, Color.White);
                    spriteBatch.Draw(back, core.ui.graphics.backRec, Color.White);
                    core.ui.SettingsButtons();
                    break;  
            }
            spriteBatch.End();
        }

        void DrawGame()
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(gameBg, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(Map, core.ui.graphics.mapRec, Color.White);
            spriteBatch.Draw(Boris, position, Color.White);

            if (EscButton) gameScene = 1;

            switch (gameScene)
            {
                case 0:
                    spriteBatch.Draw(opaqueBg, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(gameStart, core.ui.graphics.GameStartRec, Color.White); 
                    spriteBatch.Draw(Boris, core.ui.graphics.BorisRec, Color.White);
                    spriteBatch.Draw(Maxim, core.ui.graphics.MaximRec, Color.White);
                    spriteBatch.Draw(Nadya, core.ui.graphics.NadyaRec, Color.White);
                    spriteBatch.Draw(Nastya, core.ui.graphics.NastyaRec, Color.White);
                    spriteBatch.Draw(Sasha, core.ui.graphics.SashaRec, Color.White);

                    //Boris HP
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 + 612 - 102 + 204 - 36, 1080 / 2 -275 + 33), Color.White);
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 + 612 - 102 + 204 - 36 - 37, 1080 / 2 - 275 + 33), Color.White);
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 + 612 - 102 + 204 - 36 - 37 - 37, 1080 / 2 - 275 + 33), Color.White);
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 + 612 - 102 + 204 - 36 - 37 - 37 - 37, 1080 / 2 - 275 + 33), Color.White);
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 + 612 - 102 + 204 - 36 - 37 - 37 - 37 - 37, 1080 / 2 - 275 + 33), Color.White);

                    //Maxim HP
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 + 306 - 102 + 204 - 36, 1080 / 2 - 275 + 33), Color.White);
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 + 306 - 102 + 204 - 36 - 37, 1080 / 2 - 275 + 33), Color.White);
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 + 306 - 102 + 204 - 36 - 37 - 37, 1080 / 2 - 275 + 33), Color.White);

                    //Nadya HP
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 - 102 + 204 - 36, 1080 / 2 - 275 + 33), Color.White);
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 - 102 + 204 - 36 - 37, 1080 / 2 - 275 + 33), Color.White);
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 - 102 + 204 - 36 - 37 - 37, 1080 / 2 - 275 + 33), Color.White);

                    //Hastya HP
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 - 306 - 102 + 204 - 36, 1080 / 2 - 275 + 33), Color.White);
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 - 306 - 102 + 204 - 36 - 37, 1080 / 2 - 275 + 33), Color.White);
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 - 306 - 102 + 204 - 36 - 37 - 37, 1080 / 2 - 275 + 33), Color.White);

                    //Sasha HP
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 - 612 - 102 + 204 - 36, 1080 / 2 - 275 + 33), Color.White);
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 - 612 - 102 + 204 - 36 - 37, 1080 / 2 - 275 + 33), Color.White);
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 - 612 - 102 + 204 - 36 - 37 - 37, 1080 / 2 - 275 + 33), Color.White);

                    core.ui.CardSelection();
                    break;
                case 1:
                    spriteBatch.Draw(opaqueBg, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(exittomm, core.ui.graphics.exittommRec, Color.White);
                    spriteBatch.Draw(back, core.ui.graphics.backRec, Color.White);
                    spriteBatch.Draw(exitfromgame, core.ui.graphics.exitfromgameRec, Color.White);
                    core.ui.EscMenuButtons();
                    break;
                case 2:
                    break;
            }

            spriteBatch.End();
        }

        public void MouseUpdate()
        {
            mouse2 = mouse;
            mouse = Mouse.GetState();
        }

        public void KeyboardUpdate()
        {
            EscButtonState2 = EscButtonState;
            EscButtonState = Keyboard.GetState();
            Keyboardstate2 = Keyboardstate;
            Keyboardstate = Keyboard.GetState();
        }
    }
}
