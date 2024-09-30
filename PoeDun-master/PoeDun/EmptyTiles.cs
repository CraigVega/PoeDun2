using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    public class EmptyTile : Tile
    {
        // constructor that initialises the EmptyTile with a specific position, calls the base Tile class constructor to set the position of the tile
        public EmptyTile(Position position) : base(position)
        {


        }

        // overrides the Display property
        public override char Display 
        { 
            get { return '.'; } // represents the empyty tiles
        } 

    }
}

