using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    public class ExitTile : Tile
    {
        // constructor that accepts a Position parameter and passes it on the base class constructor
        public ExitTile(Position position) : base(position)
        {
        }

        // overrides the Display property to show "▒" for the exit
        public override char Display
        {
            get { return '▒'; }
        }
    }
}

