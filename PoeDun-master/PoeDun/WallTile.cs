using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    public class WallTile : Tile
    {
        // constructor that initialises the WallTile with a specific position, calls the base Tile class constructor to set the position of the tile
        public WallTile(Position posTile) : base(posTile) 
        {


        }

        // overrides the Display property
        public override char Display
        {
            get { return '█'; } // represents the wall tiles
        }
    }
}
