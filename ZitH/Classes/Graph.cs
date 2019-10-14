using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ZitH
{
    public class Graph
    {
        public Rectangle playRec;
        public Rectangle settingRec;
        public Rectangle exitRec;
        public Rectangle fullscreenRec;
        public Rectangle backRec;
        public Rectangle mapRec;
        public Rectangle exittommRec;
        public Rectangle exitfromgameRec;
        public Graph(){
            playRec = new Rectangle(1920/2-201, 1080/2-200-95, 402, 95);
            settingRec = new Rectangle(1920/2-201, 1080/2-95, 402, 95);
            exitRec = new Rectangle(1920/2-201, 1080/2+200-95, 402, 95);
            backRec = new Rectangle(1920 / 2 - 201, 1080 / 2 - 95, 402, 95);
            mapRec = new Rectangle(1920/2-795/2, 1080/2-795/2, 795, 795);
            fullscreenRec = new Rectangle(1920 / 2 - 201, 1080 / 2 - 95, 402, 95);
            exittommRec = new Rectangle(1920 / 2 - 201, 1080 / 2 - 200 - 95, 402, 95);
            exitfromgameRec = new Rectangle(1920 / 2 - 201, 1080 / 2 + 200 - 95, 402, 95);
        }
    }
}
