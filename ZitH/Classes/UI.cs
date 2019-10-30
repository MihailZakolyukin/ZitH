﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace ZitH
{
    public class UI
    {
        public Graph graphics = new Graph();
        Random random = new Random();

        public UI()
        {
            graphics = new Graph();
        }

        public void MenuButtons()
        {
            if (Mouseclick() && RecChecker(graphics.playRec))
            {
                Game1.scen = 0;
            }
            if (Mouseclick() && RecChecker(graphics.settingRec))
            {
                Game1.menuScene = 1;
            }
            if (Mouseclick() && RecChecker(graphics.exitRec))
            {
                Game1.exitGame = true;
            }
        }

        public void GameButtons()
        {
            int tmp;
            if (Mouseclick() && RecChecker(graphics.ThrowRec))
            {
                tmp = random.Next(1, 5);

                switch (tmp)
                {
                    case 1:
                        Game1.isNumber1 = true;
                        Game1.isNumber2 = false;
                        Game1.isNumber3 = false;
                        Game1.isNumber4 = false;
                        break;
                    case 2:
                        Game1.isNumber1 = false;
                        Game1.isNumber2 = true;
                        Game1.isNumber3 = false;
                        Game1.isNumber4 = false;
                        break;
                    case 3:
                        Game1.isNumber1 = false;
                        Game1.isNumber2 = false;
                        Game1.isNumber3 = true;
                        Game1.isNumber4 = false;
                        break;
                    case 4:
                        Game1.isNumber1 = false;
                        Game1.isNumber2 = false;
                        Game1.isNumber3 = false;
                        Game1.isNumber4 = true;
                        break;
                        //default:;
                }
            }
            if (Mouseclick() && RecChecker(graphics.NextTurnRec))
            {
                Game1.gameScene = 3;

                //Next after Boris
                if (Game1.BorisTurn && Game1.isMaximSelected)
                {
                    Game1.BorisTurn = false;
                    Game1.MaximTurn = true;
                }
                else if (Game1.BorisTurn && Game1.isNadyaSelected && Game1.isMaximSelected == false)
                {
                    Game1.BorisTurn = false;
                    Game1.NadyaTurn = true;
                }
                else if (Game1.BorisTurn && Game1.isNastyaSelected && Game1.isNadyaSelected == false)
                {
                    Game1.BorisTurn = false;
                    Game1.NastyaTurn = true;
                }
                else if (Game1.BorisTurn && Game1.isSashaSelected && Game1.isNastyaSelected == false)
                {
                    Game1.BorisTurn = false;
                    Game1.SashaTurn = true;
                }

                //Next after Maxim
                if (Game1.MaximTurn && Game1.isNadyaSelected)
                {
                    Game1.MaximTurn = false;
                    Game1.NadyaTurn = true;
                }
                else if (Game1.MaximTurn && Game1.isNastyaSelected && Game1.isNadyaSelected == false)
                {
                    Game1.MaximTurn = false;
                    Game1.NastyaTurn = true;
                }
                else if (Game1.MaximTurn && Game1.isSashaSelected && Game1.isNastyaSelected == false)
                {
                    Game1.MaximTurn = false;
                    Game1.SashaTurn = true;
                }
                else if (Game1.MaximTurn && Game1.isBorisSelected && Game1.isSashaSelected == false)
                {
                    Game1.MaximTurn = false;
                    Game1.BorisTurn = true;
                }

                //Next after Nadya
                if (Game1.NadyaTurn && Game1.isNastyaSelected)
                {
                    Game1.NadyaTurn = false;
                    Game1.NastyaTurn = true;
                }
                else if (Game1.NadyaTurn && Game1.isSashaSelected && Game1.isNastyaSelected == false)
                {
                    Game1.NadyaTurn = false;
                    Game1.SashaTurn = true;
                }
                else if (Game1.NadyaTurn && Game1.isBorisSelected && Game1.isSashaSelected == false)
                {
                    Game1.NadyaTurn = false;
                    Game1.BorisTurn = true;
                }
                else if (Game1.NadyaTurn && Game1.isMaximSelected && Game1.isBorisSelected == false)
                {
                    Game1.NadyaTurn = false;
                    Game1.MaximTurn = true;
                }

                //Next after Nastya
                if (Game1.NastyaTurn && Game1.isSashaSelected)
                {
                    Game1.NastyaTurn = false;
                    Game1.SashaTurn = true;
                }
                else if (Game1.NastyaTurn && Game1.isBorisSelected && Game1.isSashaSelected == false)
                {
                    Game1.NastyaTurn = false;
                    Game1.BorisTurn = true;
                }
                else if (Game1.NastyaTurn && Game1.isMaximSelected && Game1.isBorisSelected == false)
                {
                    Game1.NastyaTurn = false;
                    Game1.MaximTurn = true;
                }
                else if (Game1.NastyaTurn && Game1.isNadyaSelected && Game1.isMaximSelected == false)
                {
                    Game1.NastyaTurn = false;
                    Game1.NadyaTurn = true;
                }

                //Next after Sasha
                if (Game1.SashaTurn && Game1.isBorisSelected)
                {
                    Game1.SashaTurn = false;
                    Game1.BorisTurn = true;
                }
                else if (Game1.SashaTurn && Game1.isMaximSelected && Game1.isBorisSelected == false)
                {
                    Game1.SashaTurn = false;
                    Game1.MaximTurn = true;
                }
                else if (Game1.SashaTurn && Game1.isNadyaSelected && Game1.isMaximSelected == false)
                {
                    Game1.SashaTurn = false;
                    Game1.NadyaTurn = true;
                }
                else if (Game1.SashaTurn && Game1.isNastyaSelected && Game1.isNadyaSelected == false)
                {
                    Game1.SashaTurn = false;
                    Game1.NastyaTurn = true;
                }  
            }    
        }

        public void TurnButton()
        {
            if (Mouseclick() && RecChecker(graphics.OkRec))
            {
                Game1.gameScene = 2;    
            }
        }

        public void SettingsButtons()
        {
            //if (Mouseclick() && RecChecker(graphics.fullscreenRec))
            //{
            //    if (Game1.isfullscreen == true)
            //    {
            //        Game1.isfullscreen = false;
            //        Game1.fullscreenURL = Game1.fullscreenon;
            //    }
            //
            //    if (Game1.isfullscreen == false)
            //    {
            //        Game1.isfullscreen = true;
            //        Game1.fullscreenURL = Game1.fullscreenoff;
            //    }
            //}

            if (Mouseclick() && RecChecker(graphics.backRec))
            {
                Game1.menuScene = 0;
            }  
        }

        public void CardSelection()
        {
            if (Mouseclick() && RecChecker(graphics.BorisRec))
            {
                Game1.isBorisSelected = true;
            }

            if (Mouseclick() && RecChecker(graphics.MaximRec))
            {
                Game1.isMaximSelected = true;
            }

            if (Mouseclick() && RecChecker(graphics.NadyaRec))
            {
                Game1.isNadyaSelected = true;
            }

            if (Mouseclick() && RecChecker(graphics.NastyaRec))
            {
                Game1.isNastyaSelected = true;
            }

            if (Mouseclick() && RecChecker(graphics.SashaRec))
            {
                Game1.isSashaSelected = true;
            }

            if (Mouseclick() && RecChecker(graphics.GameStartRec))
            {
                Game1.gameScene = 2;
            }

        }

        public void EscMenuButtons()
        {

                if (Mouseclick() && RecChecker(graphics.exittommRec))
                {
                    Game1.scen = 1;
                    Game1.menuScene = 0;
                }

                if (Mouseclick() && RecChecker(graphics.backRec))
                {  
                        Game1.gameScene = 2;
                }

            if (Mouseclick() && RecChecker(graphics.exitfromgameRec))
                {
                    Game1.exitGame = true;
                }
        }

        public bool Mouseclick()
        {
            if (Game1.mouse.LeftButton == ButtonState.Pressed && Game1.mouse2.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RecChecker(Rectangle a)
        {
            if (a.Contains(Game1.mouse.Position))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
