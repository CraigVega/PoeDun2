using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    class GruntTile : EnemyTile
    {
        public GruntTile(Position pos) : base( Position , 10 ,1 )
        {
            
        }

        public override char Display
        {
            get
            {
                if (IsDead == true)
                    return 'x'; // display "x" if the hero is dead
                else
                    return 'ⓧ'; // displays "▼" if the hero is alive
            }
        }
    }
}
