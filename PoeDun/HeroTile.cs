using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    public class HeroTile : CharacterTile
    {
        // my constructor muhammad :)
        public HeroTile(Position position) : base(position,40,5)
        {
           // this.HitPoints = 40;   // this will set hit points to 40
            //this.AttackPower = 5;  // and this sets attack power to 5
        }

        // overrides the Display property
        public override char Display
        {
            get
            {
                if (IsDead == true)
                    return 'x'; // display "x" if the hero is dead
                else
                    return '▼'; // displays "▼" if the hero is alive
            }
        }

       // public int HitPoints 
        //{ 
        //   get { return HitPoints; }
       // }
       // public int AttackPower 
       // { 
            //get; 
       // }

        //public int MaxHitPoints
        //{
        //    get;

       // }
    }
}