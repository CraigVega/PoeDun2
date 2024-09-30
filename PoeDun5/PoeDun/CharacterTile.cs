using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    public abstract class CharacterTile : Tile // extends the Tile class
    {
        
        private int hitPoints;
        private int maxHitPoints;
        private int attackPower;
        public Tile[] vision; // the vision array will store the character's vision

        // constructor :)
        public CharacterTile(Position position, int hitPoints, int attackPower) 
            : base(position)
        {
            this.hitPoints = hitPoints;
            this.maxHitPoints = hitPoints; // sets maxHitPoints equal to hitPoints to be able to both be initialised by the hitPoints parameter
            this.attackPower = attackPower;
            this.vision = new Tile[4]; // the vision array that will now store 4 tiles
        }

        public CharacterTile(Position posTile) 
            : base(posTile)
        {
        }

        public bool IsDead
        {
            get { return hitPoints <= 0; } // will check the hit points everytime it is called to determine its state                        
        }
        
        // method to update vision depending on the characters position on the level
        public void UpdateVision(Level level)
        {
            // to get the characters position
            int x = this.posX;
            int y = this.posY;

            // updates the vision array with surrounding tiles (up, right, down, left)
            vision[3] = level.Tiles[x, y - 1]; // tile above
            vision[2] = level.Tiles[x + 1, y]; // tile to the right
            vision[1] = level.Tiles[x, y + 1]; // tile below
            vision[0] = level.Tiles[x - 1, y]; // tile to the left
        }

        // method for taking damage
        public void TakeDamage(int damage)
        {
            hitPoints -= damage; // subtracts the damage from the characters hit points
            if (hitPoints < 0)
            {
                hitPoints = 0; // makes sure that the hit points don't go below zero
            }
        }

        // method for attacking another character
        public void Attack(CharacterTile target)
        {
            target.TakeDamage(this.attackPower); // deals damage equal to the characters attack power
        }

        // override the abstract Display property from the Tile class
       /* public override char Display
        {
            get
            {
                return 'C'; // C represents the character
            }
        }*/
    }
}
