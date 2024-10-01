using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    public abstract class EnemyTile : CharacterTile 
    {
        int hitpoints;
        int attackPower;

        public EnemyTile(Position pos , int hitpoints , int attackPower) : base(pos , hitpoints , attackPower) 
        {
            this.hitpoints = hitpoints; ;
            this.attackPower = attackPower;

            //GetMove();
        }

        public abstract bool GetMove(out Tile targetTile);


        public abstract CharacterTile[] GetTarget(); // {  return CharacterTile[] targets ; }
    }
}
