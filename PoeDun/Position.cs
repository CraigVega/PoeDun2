using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    public class Position
    {
        private int x;
        private int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int xCord
        {
            get { return x; }
            set { x = value; }
        }

        public int yCord
        {
            get { return y; }
            set { y = value; }

        }
    }
}
