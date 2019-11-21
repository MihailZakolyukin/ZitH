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
        Random random = new Random();
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
        public static int move = 0;
        public static bool EscButton = false;
        public static bool exitGame = false;

        int i = 0, randI, randA;   //for CardSpawning method
        int b = 0;
        public static bool BorisFlag = false, MaximFlag = false, NadyaFlag = false, NastyaFlag = false, SashaFlag = false;

        public static bool isBorisSelected = false;
        public static bool isMaximSelected = false;
        public static bool isNadyaSelected = false;
        public static bool isNastyaSelected = false;
        public static bool isSashaSelected = false;

        public static bool BorisTurn = false;
        public static bool MaximTurn = false;
        public static bool NadyaTurn = false;
        public static bool NastyaTurn = false;
        public static bool SashaTurn = false;

        public static bool isNumber1 = false;
        public static bool isNumber2 = false;
        public static bool isNumber3 = false;
        public static bool isNumber4 = false;

        public static int BorisPosition;
        public static int MaximPosition;
        public static int NadyaPosition;
        public static int NastyaPosition;
        public static int SashaPosition;

        private SpriteFont font;

        private Texture2D play, settings, exit, back, ok, exittomm, exitfromgame, gameStart, NextTurn, Throw, //Buttons
            Number1, Number2, Number3, Number4, //Numbers
            menuBg, gameBg, opaqueBg, //Backgrounds
            Boris, Maxim, Nadya, Nastya, Sasha, //Humans    
            BorisHD, MaximHD, NadyaHD, NastyaHD, SashaHD, //Humans HD
            Boss, Dog, Spider, Zombie, //Enemies
            BossHD, DogHD, SpiderHD, ZombieHD, //Enemies HD
            Ak47, Axe, Crowbow, Gas, Grenade, HP, Key, Knife, Medkit, Pistol, RPG, Shotgun, Wood, //Items
            RunSmall, AkHD, AxeHD, CrowbowHD, GasHD, GrenadeHD, KeyHD, KnifeHD, MedkitHD, PistolHD, RpgHD, ShotgunHD, WoodHD, //Items HD
            Aim, RunImg, Sabre, Teeth, //Events
            Map, //Map
            BackSide; //Etc

        private Vector2[] HumPos = new Vector2[5];
        private Vector2[] position = new Vector2[55];
        private Vector2[] HMP = new Vector2[5];

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
            randI = random.Next(1, 12);
            randA = random.Next(1, 12);

            if (scen == 0 && EscButtonState.IsKeyDown(Keys.Escape) && EscButtonState2.IsKeyUp(Keys.Escape)) //Is escbutton pressed
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

            //Moving---------------------------------------------

            if (BorisTurn) {
                if (Keyboardstate.IsKeyDown(Keys.W) && Keyboardstate2.IsKeyUp(Keys.W) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Up) && Keyboardstate2.IsKeyUp(Keys.Up) && move >= 1)
                {
                    move--;
                    HumPos[BorisPosition].Y -= 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.A) && Keyboardstate2.IsKeyUp(Keys.A) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Left) && Keyboardstate2.IsKeyUp(Keys.Left) && move >= 1)
                {
                    move--;
                    HumPos[BorisPosition].X -= 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.S) && Keyboardstate2.IsKeyUp(Keys.S) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Down) && Keyboardstate2.IsKeyUp(Keys.Down) && move >= 1)
                {
                    move--;
                    HumPos[BorisPosition].Y += 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.D) && Keyboardstate2.IsKeyUp(Keys.D) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Right) && Keyboardstate2.IsKeyUp(Keys.Right) && move >= 1)
                {
                    move--;
                    HumPos[BorisPosition].X += 52;
                }
            }

            if (MaximTurn)
            {
                if (Keyboardstate.IsKeyDown(Keys.W) && Keyboardstate2.IsKeyUp(Keys.W) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Up) && Keyboardstate2.IsKeyUp(Keys.Up) && move >= 1)
                {
                    move--;
                    HumPos[MaximPosition].Y -= 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.A) && Keyboardstate2.IsKeyUp(Keys.A) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Left) && Keyboardstate2.IsKeyUp(Keys.Left) && move >= 1)
                {
                    move--;
                    HumPos[MaximPosition].X -= 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.S) && Keyboardstate2.IsKeyUp(Keys.S) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Down) && Keyboardstate2.IsKeyUp(Keys.Down) && move >= 1)
                {
                    move--;
                    HumPos[MaximPosition].Y += 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.D) && Keyboardstate2.IsKeyUp(Keys.D) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Right) && Keyboardstate2.IsKeyUp(Keys.Right) && move >= 1)
                {
                    move--;
                    HumPos[MaximPosition].X += 52;
                }
            }

            if (NadyaTurn)
            {
                if (Keyboardstate.IsKeyDown(Keys.W) && Keyboardstate2.IsKeyUp(Keys.W) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Up) && Keyboardstate2.IsKeyUp(Keys.Up) && move >= 1)
                {
                    move--;
                    HumPos[NadyaPosition].Y -= 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.A) && Keyboardstate2.IsKeyUp(Keys.A) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Left) && Keyboardstate2.IsKeyUp(Keys.Left) && move >= 1)
                {
                    move--;
                    HumPos[NadyaPosition].X -= 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.S) && Keyboardstate2.IsKeyUp(Keys.S) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Down) && Keyboardstate2.IsKeyUp(Keys.Down) && move >= 1)
                {
                    move--;
                    HumPos[NadyaPosition].Y += 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.D) && Keyboardstate2.IsKeyUp(Keys.D) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Right) && Keyboardstate2.IsKeyUp(Keys.Right) && move >= 1)
                {
                    move--;
                    HumPos[NadyaPosition].X += 52;
                }
            }

            if (NastyaTurn)
            {
                if (Keyboardstate.IsKeyDown(Keys.W) && Keyboardstate2.IsKeyUp(Keys.W) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Up) && Keyboardstate2.IsKeyUp(Keys.Up) && move >= 1)
                {
                    move--;
                    HumPos[NastyaPosition].Y -= 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.A) && Keyboardstate2.IsKeyUp(Keys.A) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Left) && Keyboardstate2.IsKeyUp(Keys.Left) && move >= 1)
                {
                    move--;
                    HumPos[NastyaPosition].X -= 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.S) && Keyboardstate2.IsKeyUp(Keys.S) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Down) && Keyboardstate2.IsKeyUp(Keys.Down) && move >= 1)
                {
                    move--;
                    HumPos[NastyaPosition].Y += 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.D) && Keyboardstate2.IsKeyUp(Keys.D) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Right) && Keyboardstate2.IsKeyUp(Keys.Right) && move >= 1)
                {
                    move--;
                    HumPos[NastyaPosition].X += 52;
                }
            }

            if (SashaTurn)
            {
                if (Keyboardstate.IsKeyDown(Keys.W) && Keyboardstate2.IsKeyUp(Keys.W) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Up) && Keyboardstate2.IsKeyUp(Keys.Up) && move >= 1)
                {
                    move--;
                    HumPos[SashaPosition].Y -= 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.A) && Keyboardstate2.IsKeyUp(Keys.A) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Left) && Keyboardstate2.IsKeyUp(Keys.Left) && move >= 1)
                {
                    move--;
                    HumPos[SashaPosition].X -= 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.S) && Keyboardstate2.IsKeyUp(Keys.S) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Down) && Keyboardstate2.IsKeyUp(Keys.Down) && move >= 1)
                {
                    move--;
                    HumPos[SashaPosition].Y += 52;
                }
                if (Keyboardstate.IsKeyDown(Keys.D) && Keyboardstate2.IsKeyUp(Keys.D) && move >= 1 || Keyboardstate.IsKeyDown(Keys.Right) && Keyboardstate2.IsKeyUp(Keys.Right) && move >= 1)
                {
                    move--;
                    HumPos[SashaPosition].X += 52;
                }
            }

            //Moving---------------------------------------------

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            switch (scen) //choosing DrawGame(); or DrawMenu();
            {
                case 0:
                    DrawGame();
                    break;
                case 1:
                    DrawMenu();
                    break;
            }
        }

        private void Load() //Loading images
        {
            font = Content.Load<SpriteFont>("ArielFont");

            play = Content.Load<Texture2D>("img/play");
            settings = Content.Load<Texture2D>("img/settings");
            exit = Content.Load<Texture2D>("img/exit");
            back = Content.Load<Texture2D>("img/back");
            ok = Content.Load<Texture2D>("img/ok");
            gameStart = Content.Load<Texture2D>("img/GameStart");
            NextTurn = Content.Load<Texture2D>("img/NextTurn");
            Throw = Content.Load<Texture2D>("img/Throw");
            exittomm = Content.Load<Texture2D>("img/exittomm");
            exitfromgame = Content.Load<Texture2D>("img/exitfromgame");

            Number1 = Content.Load<Texture2D>("img/Number1");
            Number2 = Content.Load<Texture2D>("img/Number2");
            Number3 = Content.Load<Texture2D>("img/Number3");
            Number4 = Content.Load<Texture2D>("img/Number4");

            menuBg = Content.Load<Texture2D>("img/menuBg");
            gameBg = Content.Load<Texture2D>("img/gameBg");
            opaqueBg = Content.Load<Texture2D>("img/opaqueBg");

            Boris = Content.Load<Texture2D>("img/Boris");
            Maxim = Content.Load<Texture2D>("img/Maxim");
            Nadya = Content.Load<Texture2D>("img/Nadya");
            Nastya = Content.Load<Texture2D>("img/Nastya");
            Sasha = Content.Load<Texture2D>("img/Sasha");

            BorisHD = Content.Load<Texture2D>("img/BorisHD");
            MaximHD = Content.Load<Texture2D>("img/MaxHD");
            NadyaHD = Content.Load<Texture2D>("img/NadyaHD");
            NastyaHD = Content.Load<Texture2D>("img/NastyaHD");
            SashaHD = Content.Load<Texture2D>("img/SashaHD");

            Boss = Content.Load<Texture2D>("img/Boss");
            Dog = Content.Load<Texture2D>("img/Dog");
            Spider = Content.Load<Texture2D>("img/Spider");
            Zombie = Content.Load<Texture2D>("img/Zombie");

            BossHD = Content.Load<Texture2D>("img/BossHD");
            DogHD = Content.Load<Texture2D>("img/DogHD");
            SpiderHD = Content.Load<Texture2D>("img/SpiderHD");
            ZombieHD = Content.Load<Texture2D>("img/ZombieHD");

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

            AkHD = Content.Load<Texture2D>("img/AkHD");
            AxeHD = Content.Load<Texture2D>("img/AxeHD");
            CrowbowHD = Content.Load<Texture2D>("img/CrossbowHD");
            GasHD = Content.Load<Texture2D>("img/GasHD");
            GrenadeHD = Content.Load<Texture2D>("img/GrenadeHD");
            KeyHD = Content.Load<Texture2D>("img/KeyHD");
            KnifeHD = Content.Load<Texture2D>("img/KnifeHD");
            MedkitHD= Content.Load<Texture2D>("img/MedkitHD");
            PistolHD = Content.Load<Texture2D>("img/PistolHD");
            RpgHD = Content.Load<Texture2D>("img/RpgHD");
            ShotgunHD = Content.Load<Texture2D>("img/ShotgunHD");
            WoodHD = Content.Load<Texture2D>("img/WoodHD");

            Aim = Content.Load<Texture2D>("img/Aim");
            RunImg = Content.Load<Texture2D>("img/Run");
            Sabre = Content.Load<Texture2D>("img/Sabre");
            Teeth = Content.Load<Texture2D>("img/Teeth");
            RunSmall = Content.Load<Texture2D>("img/RunSmall");

            Map = Content.Load<Texture2D>("img/Map");

            BackSide = Content.Load<Texture2D>("img/BackSide");
        }

        private void Positions() //Positions
        {
            HumPos[0] = new Vector2(1920 / 2 - 795 / 2 + 35 + 51, 1080 / 2 + 264);
            HumPos[1] = new Vector2(1920 / 2 - 795 / 2 + 35 + 51 + 52, 1080 / 2 + 264);
            HumPos[2] = new Vector2(1920 / 2 - 795 / 2 + 35 + 51, 1080 / 2 + 264 - 52);
            HumPos[3] = new Vector2(1920 / 2 - 795 / 2 + 35 + 51 + 52, 1080 / 2 + 264 - 52);
            HumPos[4] = new Vector2(1920 / 2 - 795 / 2 + 35 + 51 + 104, 1080 / 2 + 264);
            HMP[0] = new Vector2(1920 / 2 - 795 / 2 + 35 + 51 - 650, 1080 / 2 + 264 - 700);
            HMP[1] = new Vector2(1920 / 2 - 795 / 2 + 35 + 51 - 650, 1080 / 2 + 264 - 600);
            HMP[2] = new Vector2(1920 / 2 - 795 / 2 + 35 + 51 - 650, 1080 / 2 + 264 - 500);
            HMP[3] = new Vector2(1920 / 2 - 795 / 2 + 35 + 51 - 650, 1080 / 2 + 264 - 400);
            HMP[4] = new Vector2(1920 / 2 - 795 / 2 + 35 + 51 - 650, 1080 / 2 + 264 - 300);

        }

        void DrawMenu() //Drawing Menu
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

        void DrawGame() //Drawing Game
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();

            spriteBatch.Draw(gameBg, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(Map, core.ui.graphics.mapRec, Color.White);
            spriteBatch.Draw(NextTurn, core.ui.graphics.NextTurnRec, Color.White);
            spriteBatch.Draw(Throw, core.ui.graphics.ThrowRec, Color.White);

            CardSpawning();

            if (isBorisSelected)
            {
                spriteBatch.Draw(Boris, HMP[BorisPosition], Color.White);
                spriteBatch.Draw(Boris, HumPos[BorisPosition], Color.White);
                if (!BorisFlag)
                {
                    BorisPosition = b;
                    b++;
                    BorisFlag = true;
                }
            }   
            if (isMaximSelected)
            {
                spriteBatch.Draw(Maxim, HMP[MaximPosition], Color.White);
                spriteBatch.Draw(Maxim, HumPos[MaximPosition], Color.White);
                if (!MaximFlag)
                {
                    MaximPosition = b;
                    b++;
                    MaximFlag = true;
                }
            }
            if (isNadyaSelected)
            {
                spriteBatch.Draw(Nadya, HMP[NadyaPosition], Color.White);
                spriteBatch.Draw(Nadya, HumPos[NadyaPosition], Color.White);
                if (!NadyaFlag)
                {
                    NadyaPosition = b;
                    b++;
                    NadyaFlag = true;
                }
            }
            if (isNastyaSelected)
            {
                spriteBatch.Draw(Nastya, HMP[NastyaPosition], Color.White);
                spriteBatch.Draw(Nastya, HumPos[NastyaPosition], Color.White);
                if (!NastyaFlag)
                {
                    NastyaPosition = b;
                    b++;
                    NastyaFlag = true;
                }
            }
            if (isSashaSelected)
            {
                spriteBatch.Draw(Sasha, HMP[SashaPosition], Color.White);
                spriteBatch.Draw(Sasha, HumPos[SashaPosition], Color.White);
                if (!SashaFlag)
                {
                    SashaPosition = b;
                    b++;
                    SashaFlag = true;
                }
            }

            if (isNumber1)
            {
                spriteBatch.Draw(Number1, core.ui.graphics.ThrowNumberRec, Color.White);
                spriteBatch.Draw(RunImg, core.ui.graphics.EventRec, Color.White);
            }
            if (isNumber2)
            {
                spriteBatch.Draw(Number2, core.ui.graphics.ThrowNumberRec, Color.White);
                spriteBatch.Draw(Teeth, core.ui.graphics.EventRec, Color.White);
            }
            if (isNumber3)
            {
                spriteBatch.Draw(Number3, core.ui.graphics.ThrowNumberRec, Color.White);
                spriteBatch.Draw(Sabre, core.ui.graphics.EventRec, Color.White);
            }
            if (isNumber4)
            {
                spriteBatch.Draw(Number4, core.ui.graphics.ThrowNumberRec, Color.White);
                spriteBatch.Draw(Aim, core.ui.graphics.EventRec, Color.White);
            }

            if (EscButton) gameScene = 1;

            core.ui.GameButtons();
            switch (gameScene) //0-Card selection, 1-Esc menu, 2-Game, 3-Turn menu;
            {
                case 0:
                    spriteBatch.Draw(opaqueBg, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(gameStart, core.ui.graphics.GameStartRec, Color.White);
                    spriteBatch.Draw(BorisHD, core.ui.graphics.BorisRec, Color.White);
                    spriteBatch.Draw(MaximHD, core.ui.graphics.MaximRec, Color.White);
                    spriteBatch.Draw(NadyaHD, core.ui.graphics.NadyaRec, Color.White);
                    spriteBatch.Draw(NastyaHD, core.ui.graphics.NastyaRec, Color.White);
                    spriteBatch.Draw(SashaHD, core.ui.graphics.SashaRec, Color.White);

                    //Boris HP
                    spriteBatch.Draw(HP, new Vector2(1920 / 2 + 612 - 102 + 204 - 36, 1080 / 2 - 275 + 33), Color.White);
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

                    //Humans features
                    spriteBatch.Draw(Knife, new Vector2(1920 / 2 - 612 - 51 + 20, 1080 / 2 + 51 - 30), Color.White);
                    spriteBatch.Draw(Medkit, new Vector2(1920 / 2 - 306 - 51 + 20, 1080 / 2 + 51 - 30), Color.White);
                    //spriteBatch.Draw(Medkit, new Vector2(1920 / 2 - 306 - 51 - 30, 1080 / 2 + 51 - 30), Color.White);
                    //spriteBatch.Draw(Plus, new Vector2(1920 / 2 - 306 - 30, 1080 / 2 + 6), Color.White);
                    //spriteBatch.Draw(HP, new Vector2(1920 / 2 - 306 + 80 - 30, 1080 / 2 + 30), Color.White);
                    spriteBatch.Draw(Pistol, new Vector2(1920 / 2 - 102 + 51 + 20, 1080 / 2 + 51 - 30), Color.White);
                    spriteBatch.Draw(RunSmall, new Vector2(1920 / 2 + 306 + 51 - 90, 1080 / 2 + 51 - 30), Color.White);

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
                    spriteBatch.DrawString(font, $"Moves: {Convert.ToString(move)}", new Vector2(1920 / 2 - 50 - 850, 1080 / 2 - 100 + 200 ), Color.Red);
                    break;
                case 3:
                    if (BorisTurn)
                    {
                        spriteBatch.Draw(opaqueBg, new Vector2(0, 0), Color.White);
                        spriteBatch.DrawString(font, "Boris's turn", new Vector2(1920 / 2 - 100, 1080 / 2 - 100), Color.Yellow);
                        spriteBatch.Draw(ok, core.ui.graphics.OkRec, Color.White);
                    }
                    if (MaximTurn)
                    {
                        spriteBatch.Draw(opaqueBg, new Vector2(0, 0), Color.White);
                        spriteBatch.DrawString(font, "Maxim's turn", new Vector2(1920 / 2 - 100, 1080 / 2 - 100), Color.Yellow);
                        spriteBatch.Draw(ok, core.ui.graphics.OkRec, Color.White);
                    }
                    if (NadyaTurn)
                    {
                        spriteBatch.Draw(opaqueBg, new Vector2(0, 0), Color.White);
                        spriteBatch.DrawString(font, "Nadya's turn", new Vector2(1920 / 2 - 100, 1080 / 2 - 100), Color.Yellow);
                        spriteBatch.Draw(ok, core.ui.graphics.OkRec, Color.White);
                    }
                    if (NastyaTurn)
                    {
                        spriteBatch.Draw(opaqueBg, new Vector2(0, 0), Color.White);
                        spriteBatch.DrawString(font, "Nastya's turn", new Vector2(1920 / 2 - 100, 1080 / 2 - 100), Color.Yellow);
                        spriteBatch.Draw(ok, core.ui.graphics.OkRec, Color.White);
                    }
                    if (SashaTurn)
                    {
                        spriteBatch.Draw(opaqueBg, new Vector2(0, 0), Color.White);
                        spriteBatch.DrawString(font, "Sasha's turn", new Vector2(1920 / 2 - 100, 1080 / 2 - 100), Color.Yellow);
                        spriteBatch.Draw(ok, core.ui.graphics.OkRec, Color.White);
                    }               
                    core.ui.TurnButton();
                    break;
            }

            spriteBatch.End();
        }

        public void MouseUpdate() //Update mouse for clicking
        {
            mouse2 = mouse;
            mouse = Mouse.GetState();
        }

        public void KeyboardUpdate() //Keyboard update for moving
        {
            EscButtonState2 = EscButtonState;
            EscButtonState = Keyboard.GetState();
            Keyboardstate2 = Keyboardstate;
            Keyboardstate = Keyboard.GetState();
        }

        public void CardSpawning() //Spawning 55 cards on the map
        {
            if(i <= 54) { 
                position[i] = new Vector2(1920 / 2 - 795 / 2 + 35 + 51 + 52 * randI, 1080 / 2 - 52 * randA + 264);
                i++;
            }

            //idk what i'm doing wrong, this fucking loop doesn't work
            spriteBatch.Draw(BackSide, position[0], Color.White);
            spriteBatch.Draw(BackSide, position[1], Color.White);
            spriteBatch.Draw(BackSide, position[2], Color.White);
            spriteBatch.Draw(BackSide, position[3], Color.White);
            spriteBatch.Draw(BackSide, position[4], Color.White);
            spriteBatch.Draw(BackSide, position[5], Color.White);
            spriteBatch.Draw(BackSide, position[6], Color.White);
            spriteBatch.Draw(BackSide, position[7], Color.White);
            spriteBatch.Draw(BackSide, position[8], Color.White);
            spriteBatch.Draw(BackSide, position[9], Color.White);
            spriteBatch.Draw(BackSide, position[10], Color.White);
            spriteBatch.Draw(BackSide, position[11], Color.White);
            spriteBatch.Draw(BackSide, position[12], Color.White);
            spriteBatch.Draw(BackSide, position[13], Color.White);
            spriteBatch.Draw(BackSide, position[14], Color.White);
            spriteBatch.Draw(BackSide, position[15], Color.White);
            spriteBatch.Draw(BackSide, position[16], Color.White);
            spriteBatch.Draw(BackSide, position[17], Color.White);
            spriteBatch.Draw(BackSide, position[18], Color.White);
            spriteBatch.Draw(BackSide, position[19], Color.White);
            spriteBatch.Draw(BackSide, position[20], Color.White);
            spriteBatch.Draw(BackSide, position[21], Color.White);
            spriteBatch.Draw(BackSide, position[22], Color.White);
            spriteBatch.Draw(BackSide, position[23], Color.White);
            spriteBatch.Draw(BackSide, position[24], Color.White);
            spriteBatch.Draw(BackSide, position[25], Color.White);
            spriteBatch.Draw(BackSide, position[26], Color.White);
            spriteBatch.Draw(BackSide, position[27], Color.White);
            spriteBatch.Draw(BackSide, position[28], Color.White);
            spriteBatch.Draw(BackSide, position[29], Color.White);
            spriteBatch.Draw(BackSide, position[30], Color.White);
            spriteBatch.Draw(BackSide, position[31], Color.White);
            spriteBatch.Draw(BackSide, position[32], Color.White);
            spriteBatch.Draw(BackSide, position[33], Color.White);
            spriteBatch.Draw(BackSide, position[34], Color.White);
            spriteBatch.Draw(BackSide, position[35], Color.White);
            spriteBatch.Draw(BackSide, position[36], Color.White);
            spriteBatch.Draw(BackSide, position[37], Color.White);
            spriteBatch.Draw(BackSide, position[38], Color.White);
            spriteBatch.Draw(BackSide, position[39], Color.White);
            spriteBatch.Draw(BackSide, position[40], Color.White);
            spriteBatch.Draw(BackSide, position[41], Color.White);
            spriteBatch.Draw(BackSide, position[42], Color.White);
            spriteBatch.Draw(BackSide, position[43], Color.White);
            spriteBatch.Draw(BackSide, position[44], Color.White);
            spriteBatch.Draw(BackSide, position[45], Color.White);
            spriteBatch.Draw(BackSide, position[46], Color.White);
            spriteBatch.Draw(BackSide, position[47], Color.White);
            spriteBatch.Draw(BackSide, position[48], Color.White);
            spriteBatch.Draw(BackSide, position[49], Color.White);
            spriteBatch.Draw(BackSide, position[50], Color.White);
            spriteBatch.Draw(BackSide, position[51], Color.White);
            spriteBatch.Draw(BackSide, position[52], Color.White);
            spriteBatch.Draw(BackSide, position[53], Color.White);
            spriteBatch.Draw(BackSide, position[54], Color.White);
        }
    }
}
