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
        public Graph(){
            playRec = new Rectangle(500, 87 * 2, 255, 66);
            settingRec = new Rectangle(500, 87 * 3, 255, 66);
            exitRec = new Rectangle(500, 87 * 4, 255, 66);
        }
    }
}
