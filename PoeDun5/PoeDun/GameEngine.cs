using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PoeDun.Level;

namespace PoeDun
{
    public enum GameState
    {
        InProgress,
        Complete,
        GameOver
    }
    class GameEngine
    {
        private GameState gameState = GameState.InProgress;
        private int currentLevelNumber = 1;
        const int MIN_SIZE = 10;
        const int MAX_SIZE = 20;
        private Level currentLevel;
        private int numLevels;
        private Random randomNum = new Random();
        int width;
        int height;


        public GameEngine(int numLevels)
        {

            this.numLevels = numLevels;

            this.width = randomNum.Next(MIN_SIZE, MAX_SIZE);
            this.height = randomNum.Next(MIN_SIZE, MAX_SIZE);
            this.currentLevel = new Level(this.width, this.height);
        }



        public override string ToString()
        {
            if (gameState == GameState.Complete)
            {
                MessageBox.Show("You have completed the game!");
            }
            return currentLevel.ToString();

        }



       
        private bool MoveHero(Direction direct)
        {
            bool move = false;
            Tile targetTileCheck = null;
            int numCheck;

            currentLevel.heroTile.UpdateVision(currentLevel);
            Debug.WriteLine("Switch");
            switch (direct)
            {
                case Direction.up:
                    targetTileCheck = currentLevel.heroTile.vision[0];
                    numCheck = 0;
                    break;

                case Direction.Right:
                    targetTileCheck = currentLevel.heroTile.vision[1];
                    numCheck = 1;
                    break;

                case Direction.Down:
                    targetTileCheck = currentLevel.heroTile.vision[2];
                    numCheck = 2;
                    break;

                case Direction.Left:
                    targetTileCheck = currentLevel.heroTile.vision[3];
                    numCheck = 3;
                    break;

               // default:                      //Deafalt if nothing
                //    targetTileCheck = null;
                //    break;


            }

            if (targetTileCheck is ExitTile)
            {
                if (currentLevelNumber < 10)
                {
                    NextLevel();
                    return true;
                }

                else
                {
                    gameState = GameState.Complete;
                    return false;
                    ToString();
                }
            }
            else if (targetTileCheck is EmptyTile)
            {
                currentLevel.SwopTiles(targetTileCheck , currentLevel.heroTile);
                Debug.WriteLine("Empty Tile");
                currentLevel.heroTile.UpdateVision(currentLevel);
                return true;
        
            }
            Debug.WriteLine("Outside");
            return false;



        }



        public void TriggerMovement(Direction direct)
        {
            MoveHero(direct);
        }

        private void NextLevel()
        {
            currentLevelNumber++; // increments the current level number

            HeroTile currentHero = currentLevel.heroTile; // will temporarily store the current HeroTile

            // generates a random size for the next level
            Random random = new Random();
            int newWidth = random.Next(MIN_SIZE, MAX_SIZE);
            int newHeight = random.Next(MIN_SIZE, MAX_SIZE);
            currentLevel = new Level(newWidth, newHeight, currentHero); // creates a new level with the stored HeroTile

            gameState = GameState.InProgress; // will set the game state to InProgress for the new level
        }
    }


}