using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    class GruntTile : EnemyTile
    {
        Position posGrunt;
        public GruntTile(Position pos) : base( pos , 10 ,1 )
        {
            this.posGrunt = new Position(pos.xCord , pos.yCord);
        }

        public override char Display
        {
            get
            {
                if (IsDead == true)
                    return 'x'; // display "x" if the Grunt eniemies is dead
                else
                    return 'Ϫ'; // displays "Ϫ" if the Grunt eniemies is alive
            }
        }

        public override bool GetMove(out Tile targetTile)
        {
            
        }
    }
}
