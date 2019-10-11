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

        public static int scen = 1; 
        public static int menuScene = 0;
        public static bool EscButton = false;
        public static bool exitGame = false;

        public static string fullscreenon = "img/fullscreenon";
        public static string fullscreenoff = "img/fullscreenoff";
        public static string fullscreenURL = "img/fullscreenoff";

        public static bool isfullscreen = true;

        Texture2D play, settings, exit, fullscreen, back, exittomm, exitfromgame, //Buttons
            menuBg, gameBg, opaqueBg, //Backgrounds
            Map;

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
            Load();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (scen == 0 && Keyboard.GetState().IsKeyDown(Keys.Escape))
                EscButton = true;

            MouseUpdate();
            if (exitGame)
            {
                Exit();
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
            exittomm = Content.Load<Texture2D>("img/exittomm");
            exitfromgame = Content.Load<Texture2D>("img/exitfromgame");
            menuBg = Content.Load<Texture2D>("img/menuBg");
            gameBg = Content.Load<Texture2D>("img/gameBg");
            opaqueBg = Content.Load<Texture2D>("img/opaqueBg");
            fullscreen = Content.Load<Texture2D>(fullscreenURL);
            Map = Content.Load<Texture2D>("img/Map");
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
                    spriteBatch.Draw(fullscreen, core.ui.graphics.fullscreenRec, Color.White);
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

            if (EscButton)
            {
                spriteBatch.Draw(opaqueBg, new Vector2(0, 0), Color.White);
                spriteBatch.Draw(exittomm, core.ui.graphics.exittommRec, Color.White);
                spriteBatch.Draw(back, core.ui.graphics.backRec, Color.White);
                spriteBatch.Draw(exitfromgame, core.ui.graphics.exitfromgameRec, Color.White);
                core.ui.EscMenuButtons();
            }

            spriteBatch.End();
        }

        public void MouseUpdate()
        {
            mouse = mouse2;
            mouse = Mouse.GetState();
        }
    }
}
