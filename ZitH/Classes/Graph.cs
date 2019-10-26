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
        //public Rectangle fullscreenRec;
        public Rectangle backRec;
        public Rectangle EventRec;
        public Rectangle ThrowNumberRec;
        public Rectangle BorisRec;
        public Rectangle MaximRec;
        public Rectangle NadyaRec;
        public Rectangle NastyaRec;
        public Rectangle SashaRec; 
        public Rectangle mapRec;
        public Rectangle GameStartRec;
        public Rectangle NextTurnRec;
        public Rectangle ThrowRec;
        public Rectangle exittommRec;
        public Rectangle exitfromgameRec;
        public Graph(){
            playRec = new Rectangle(1920/2-201, 1080/2-200-95, 402, 95);
            settingRec = new Rectangle(1920/2-201, 1080/2-95, 402, 95);
            exitRec = new Rectangle(1920/2-201, 1080/2+200-95, 402, 95);

            EventRec = new Rectangle(1920 / 2 + 50, 1080 / 2 - 100, 100, 100);
            ThrowNumberRec = new Rectangle(1920 / 2 - 50, 1080 / 2 - 100, 100, 100);

            //fullscreenRec = new Rectangle(1920 / 2 - 201, 1080 / 2 - 200 - 95, 402, 95);
            backRec = new Rectangle(1920 / 2 - 201, 1080 / 2 - 95, 402, 95);

            BorisRec = new Rectangle(1920 / 2 + 612 - 102, 1080 / 2 - 204, 204, 204);
            MaximRec = new Rectangle(1920 / 2 + 306 - 102, 1080 / 2 - 204, 204, 204);
            NadyaRec = new Rectangle(1920 / 2 - 102, 1080 / 2 - 204, 204, 204);
            NastyaRec = new Rectangle(1920 / 2 - 306 - 102, 1080 / 2 - 204, 204, 204);
            SashaRec = new Rectangle(1920 / 2 - 612 - 102, 1080 / 2 - 204, 204, 204);
    
            mapRec = new Rectangle(1920/2-795/2, 1080/2-795/2, 795, 795);

            GameStartRec = new Rectangle(1920 / 2 - 171/2 + 400, 1080 / 2 -50 + 400, 171, 50);

            NextTurnRec = new Rectangle(1920 / 2 - 171 / 2 + 550, 1080 / 2 - 50 + 380, 171, 50);

            ThrowRec = new Rectangle(1920 / 2 - 171 / 2 - 500, 1080 / 2 - 50 + 300, 171, 50);

            exittommRec = new Rectangle(1920 / 2 - 201, 1080 / 2 - 200 - 95, 402, 95);
            exitfromgameRec = new Rectangle(1920 / 2 - 201, 1080 / 2 + 200 - 95, 402, 95);

        }
    }
}
