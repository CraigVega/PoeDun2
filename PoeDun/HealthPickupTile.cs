using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    public class HealthPickupTile : PickupTile
    {
        public HealthPickupTile(Position position) : base(position)
        {
        }

        // implement the ApplyEffect method to heal the character
        public override void ApplyEffect(CharacterTile character)
        {
            character.Heal(10); // heal the character by 10 hit points
        }

        // override the Display property to show '+'
        public override char Display
        {
            get { return '+'; }
        }
    }
}
