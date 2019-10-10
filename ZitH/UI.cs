using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ZitH
{
    public class UI
    {
        public Graph graphics = new Graph();

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

        public void SettingsButtons()
        {
            if (Mouseclick() && RecChecker(graphics.fullscreenRec))
            {
                if (Game1.isfullscreen == true)
                {
                    Game1.isfullscreen = false;
                    Game1.fullscreenURL = Game1.fullscreenon;
                }

                if (Game1.isfullscreen == false)
                {
                    Game1.isfullscreen = true;
                    Game1.fullscreenURL = Game1.fullscreenoff;
                }
            }

            if (Mouseclick() && RecChecker(graphics.backRec))
            {
                Game1.menuScene = 0;
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
