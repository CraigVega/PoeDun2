using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    class GruntTile : EnemyTile
    {
        // constructor calls the base constructor of EnemyTile with position, 10 hit points, and 1 attack power
        public GruntTile(Position pos) : base(pos, 10, 1)
        {
            
        }

        // overrides the Display property
        public override char Display
        {
            get
            {
                // if the grunt is dead, return 'X'
                if (IsDead == true)
                    return 'X';
                else
                    // if the grunt is alive, return 'Ϫ' 
                    return 'Ϫ';
            }
        }

        // method to determine the grunt's next move
        // returns true if a valid move is found, otherwise false
        public override bool GetMove(out Tile nextTile)
        {
            // array to store empty tiles around the grunt (max size 4 for the 4 directions)
            Tile[] emptyTiles = new Tile[4];
            int emptyTileCount = 0; // counter to track how many empty tiles are found
            Random random = new Random(); // random number generator for picking a random empty tile

            // loop through the grunt's vision array (up, right, down, left)
            for (int i = 0; i < vision.Length; i++)
            {
                // if a tile in vision is an EmptyTile, add it to the emptyTiles array
                if (vision[i] is EmptyTile)
                {
                    emptyTiles[emptyTileCount] = vision[i]; // add to emptyTiles array
                    emptyTileCount++; // increment the counter of empty tiles
                }
            }

            // if no empty tiles are found, the grunt cannot move
            if (emptyTileCount == 0)
            {
                nextTile = null; // no move possible, set nextTile to null
                return false; // return false since no move can be made
            }

            // if empty tiles are found, select one at random and assign it to nextTile
            nextTile = emptyTiles[random.Next(emptyTileCount)];
            return true; // return true since a move was made
        }

        // method to find and return targets (heroes) in the grunt's vision
        // returns an array of CharacterTile (targets), including HeroTile
        public override CharacterTile[] GetTargets()
        {
            // array to store potential targets (maximum size is vision.Length)
            CharacterTile[] targets = new CharacterTile[vision.Length];
            int targetCount = 0; // counter to track how many targets are found

            // loops through the grunt's vision array
            for (int i = 0; i < vision.Length; i++)
            {
                // if a HeroTile is found in vision, add it to the targets array
                if (vision[i] is HeroTile hero)
                {
                    targets[targetCount] = hero; // add the hero to the targets array
                    targetCount++; // increment the target counter
                }
            }

            // create a new array with the exact number of found targets
            CharacterTile[] foundTargets = new CharacterTile[targetCount];

            // copy the found targets to the new array
            for (int i = 0; i < targetCount; i++)
            {
                foundTargets[i] = targets[i];
            }

            // return the array of found targets or an empty array
            return foundTargets;
        }
    }
}
