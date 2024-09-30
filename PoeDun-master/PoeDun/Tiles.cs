using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    public abstract class Tile
    {
        private Position posTile;

        public Tile(Position posTile)
        {
            this.posTile = posTile;
        }

        public int posX
        {
            get { return posTile.xCord; }
            //set { posTile.xCord = value; }
        }

        public int posY
        {
            get { return posTile.yCord; }
            //set { posTile.yCord = value; }
        }

        public abstract char Display
        {
            get;
        }
        public bool IsEmpty { get; internal set; }

        public override string ToString()
        {
            return Display.ToString(); // Return the display character
        }
    }
}
