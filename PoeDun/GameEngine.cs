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
        private int width;
        private int height;
        private int heroMoveCount = 0;
        

        // constructor to initialize the GameEngine with the number of levels
        public GameEngine(int numLevels)
        {
            this.numLevels = numLevels;
            this.width = randomNum.Next(MIN_SIZE, MAX_SIZE);
            this.height = randomNum.Next(MIN_SIZE, MAX_SIZE);
            // initialize the first level with zero enemies and pickups (or any default values)
            currentLevel = new Level(this.width, this.height, 1, 2);
            
        }

        // method to create a new level with specified number of enemies and pickups
        public void CreateNewLevel(int width, int height, int numberOfEnemies, int numberOfPickups) //Have not gotten this to work
        {
            // create a new level and pass the number of enemies and pickups
            currentLevel = new Level(width, height, numberOfEnemies, numberOfPickups);
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
                }
            }
            else if (targetTileCheck is PickupTile pickupTile)
            {
                
                pickupTile.ApplyEffect(currentLevel.heroTile); // applies the effect of the pickup
                currentLevel.SwopTiles(new EmptyTile(targetTileCheck.Pos), currentLevel.heroTile); // replaces PickupTile with EmptyTile
                Debug.WriteLine("Picked up item");
                currentLevel.heroTile.UpdateVision(currentLevel);
                currentLevel.UpdateVision();
                return true;
            }

            else if (targetTileCheck is EmptyTile)
            {
                currentLevel.SwopTiles(targetTileCheck, currentLevel.heroTile);
                Debug.WriteLine("Empty Tile");
                currentLevel.heroTile.UpdateVision(currentLevel);
                currentLevel.UpdateVision(); // Update the vision for both hero and enemies
                return true;
            }

            Debug.WriteLine("Outside");
            return false;
        }

        public void TriggerMovement(Direction direct)
        {
            if (gameState == GameState.InProgress)
            {
                if (MoveHero(direct))
                {
                    heroMoveCount++;

                   
                    if (heroMoveCount % 2 == 0)  // Move enemies after every 2 successful hero moves as the % gets if the number is divisible by 2
                    {
                        MoveEnemies();
                    }
                }
            }

            else
            {
                //stuff
            }
        }

        private void NextLevel()
        {
            currentLevelNumber++; // increments the current level number

            HeroTile currentHero = currentLevel.heroTile; // temporarily store the current HeroTile

            // generates a random size for the next level
            int newWidth = randomNum.Next(MIN_SIZE, MAX_SIZE);
            int newHeight = randomNum.Next(MIN_SIZE, MAX_SIZE);

            int numberOfEnemies = currentLevelNumber; // Increase number of enemies based on level number
            // creates a new level with the current hero, and specify the number of enemies and pickups
            //CreateNewLevel(newWidth, newHeight, numberOfEnemies, 2, currentHero); // Not working
            currentLevel = new Level(newWidth, newHeight, numberOfEnemies, 2, currentHero);

            gameState = GameState.InProgress; // set the game state to InProgress for the new level
        }

        private void MoveEnemies()
        {
            EnemyTile currentEmemy;

            foreach (EnemyTile enemy in currentLevel.Enemies)
            {
                if (enemy.IsDead)
                {
                    // Skip dead enemies
                    continue;
                }

                // Get the next move for the enemy
                if (enemy.GetMove(out Tile targetTile))
                {
                    // Check if the move is valid (targetTile should be an EmptyTile)
                    if (targetTile is EmptyTile)
                    {
                        // Swap the enemy with the target tile
                        currentLevel.SwopTiles(targetTile, enemy);

                        // Update vision after moving the enemy
                        currentLevel.UpdateVision();
                    }
                }
            }

        }

        private bool HeroAttack(Direction direction)
        {
            
            Tile AttackTargetTile = currentLevel.heroTile.vision[(int)direction];

            if (AttackTargetTile is CharacterTile targetCharacterTile)
            {
                currentLevel.heroTile.Attack(targetCharacterTile);
                return true;
            }

            else
            {
                return false;
            }
        }

        public void TriggerAttack(Direction direction)
        {
            // HeroAttack(direction);
            if (gameState == GameState.InProgress)
            {
                if (HeroAttack(direction) == true)
                {
                    EnemiesAttack();

                    if (currentLevel.heroTile.IsDead)
                    {
                        gameState = GameState.GameOver;
                    }
                }

            }

            else
            {
               // if (gameState == GameState.GameOver)
               // {

                //}
            }
        }

        private void EnemiesAttack()
        {
            foreach (EnemyTile enemy in currentLevel.Enemies)
            {
                if (enemy.IsDead)
                {
                    
                    continue;
                }

                else
                {
                    //Debug.WriteLine("Else working");
                    enemy.GetTargets();
                    Debug.WriteLine("Target working");


                    foreach (HeroTile target in enemy.GetTargets())
                    {
                       // currentLevel.Enemies.Attack(target);
                        enemy.Attack(target);
                    }

                   
                   
                }
            }
        }

       public string HeroStats
        {
            get { return Convert.ToString(currentLevel.heroTile.HitPoints) + "/" + Convert.ToString(currentLevel.heroTile.MaxHitPoints); }

        }

        public string HealthDisplay()
        {
            return HeroStats;
        }
      
    }
}