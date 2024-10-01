using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    public abstract class PickupTile : Tile
    {
        public PickupTile(Position position) : base(position)
        {
        }

        // abstract method that indicates the target being healed
        public abstract void ApplyEffect(CharacterTile character);
    }
}
