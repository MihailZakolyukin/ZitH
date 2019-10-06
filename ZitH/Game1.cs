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
        public static bool exitGame = false;

        Texture2D play, settings, exit, menuBg;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            base.Draw(gameTime);
        }

        private void Load()
        {
            play = Content.Load<Texture2D>("play");
            settings = Content.Load<Texture2D>("settings");
            exit = Content.Load<Texture2D>("exit");
            menuBg = Content.Load<Texture2D>("menuBg");
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
                //case 1:
                //   if (debuggingMode == true)
                //    {
                //        spriteBatch.Draw(disableDebug, core.ui.graphics.disableRec, Color.White);
                //    }
                //    else
                //    {
                //       spriteBatch.Draw(debug, core.ui.graphics.debugRec, Color.White);
                //    }
                //    spriteBatch.Draw(back, core.ui.graphics.backRec, Color.White);
                //    if (debuggingMode == true && menuScene == 1)
                //    {
                //        core.ui.DisableButton();
                //   }
                //    else
                //    {
                //        core.ui.SettingsButtons();
                //    }
                //    break;
            }
            spriteBatch.End();
        }
    }
}
