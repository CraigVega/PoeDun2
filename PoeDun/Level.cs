using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    public class Level
    {
        Tile[,] tiles;
        private EnemyTile[] enemies; // array to store all the enemies
        int width;
        int height;
        HeroTile Hero;
        ExitTile Exit;

        private PickupTile[] pickups; // array to store pickups in the level

        public Level(int width, int height, int numberOfEnemies, int numberOfPickups, HeroTile Hero = null, ExitTile exit = null) // added numberOfPickups to constructor
        {
            this.width = width;
            this.height = height;

            tiles = new Tile[width, height];  // No need for Tile[,] tiles as we already declared it above in the field
            InitialiseTiles();
            enemies = new EnemyTile[numberOfEnemies]; // initialize the enemies array

            pickups = new PickupTile[numberOfPickups]; // initialize the pickups array with the given number of pickups

            // Place HeroTile
            Position randomHeroPos = GetRandomEmptyPosition();  // gets random empty position for hero

            if (Hero == null) // if Hero == null then a new HeroTile will be created at that position
            {
                this.Hero = (HeroTile)CreateTile(TileType.Hero, randomHeroPos);
                //Debug.WriteLine("hero");
            }
            else
            {
                // places the HeroTile at its position in the tiles array
                Hero.Pos = randomHeroPos;
                tiles[randomHeroPos.xCord, randomHeroPos.yCord] = Hero;
                this.Hero = Hero;
            }



            // places ExitTile after HeroTile
            Position exitPos = GetRandomEmptyPosition();  // gets random empty position for exit
            if (Exit == null)
            {
               this.Exit = (ExitTile)CreateTile(TileType.Exit, exitPos);  // creates and place ExitTile
            }
            else
            {
                Exit.Pos = exitPos;
                tiles[exitPos.xCord, exitPos.yCord] = Exit;
                this.Exit = Exit;
            }

            for (int i = 0; i < numberOfEnemies; i++) // loops through the number of enemies to initialize and place them in the level
            {
                Position enemyPos = GetRandomEmptyPosition(); // gets random empty position for enemy
                enemies[i] = (EnemyTile)CreateTile(TileType.Enemy, enemyPos); // creates and places enemy
            }

            for (int i = 0; i < numberOfPickups; i++) // loops through the number of pickups to initialize and place them in the level
            { 
                Position pickupPos = GetRandomEmptyPosition(); // gets random empty position for pickup
                pickups[i] = (PickupTile)CreateTile(TileType.Pickup, pickupPos); // creates and places pickup
            }
        }

        public Level(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        enum TileType
        {
            Empty,
            Wall,
            Hero, // added Hero to enum 
            Exit, // added Exit to enum
            Pickup, // added pickup to enum
            Enemy, // added Enemy to enum
        }

        // property to expose the tiles array
        public Tile[,] Tiles
        {
            get { return tiles; }
        }

        // property to expose the pickups array
        public PickupTile[] Pickups 
        { 
            get { return pickups; } 
        }

        //property to expose the Emeies  array ( for GameEngine)
        public EnemyTile[] Enemies
        {
            get { return enemies; }
        }

        private Tile CreateTile(TileType tiletype, Position position)
        {
            Tile tile;
            switch (tiletype)
            {
                case TileType.Empty:
                    tile = new EmptyTile(position);
                    break;

                case TileType.Wall:
                    tile = new WallTile(position);
                    break;

                case TileType.Hero:     //Added hero to be placed in when constructiong 
                    tile = new HeroTile(position);
                    break;

                case TileType.Exit: // added case for ExitTile
                    tile = new ExitTile(position);
                    break;
                case TileType.Enemy: // added case for EnemyTile
                    tile = new GruntTile(position);
                    break;
                case TileType.Pickup: // added case for PickupTile
                    tile = new HealthPickupTile(position);
                    break;

                default:
                    tile = null;
                    break;
            }

            tiles[position.xCord, position.yCord] = tile;
            return tiles[position.xCord, position.yCord];
        }

        private Tile CreateTile(TileType tiletype, int x, int y)
        {
            Tile tile;
            switch (tiletype)
            {
                case TileType.Empty:
                    tile = new EmptyTile(new Position(x, y));
                    break;

                case TileType.Wall:
                    tile = new WallTile(new Position(x, y));
                    break;

                case TileType.Hero:
                    tile = new HeroTile(new Position(x, y)); // Added hero to be placed in when constructiong
                    break;

                case TileType.Exit:
                    tile = new ExitTile(new Position(x, y)); // added the Exit tile
                    break;
                case TileType.Enemy:
                    tile = new GruntTile(new Position(x, y)); // added the Grunt tile
                    break;
                case TileType.Pickup:
                    tile = new HealthPickupTile(new Position(x, y)); // added the HealthPickup tile
                    break;

                default:
                    tile = null;
                    break;
            }

            tiles[x, y] = tile;
            return tiles[x, y];
        }

        // method to update the vision of hero enemies
        public void UpdateVision()
        {
            Hero.UpdateVision(this); // update heros vision

            foreach (var enemy in enemies) // iterates through each enemy in the enemies array
            {
                if (enemy != null) // checks if the current enemy exists
                {
                    enemy.UpdateVision(this); // update each enemies vision
                }
            }
        }

        public void InitialiseTiles()
        {
            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    Position position = new Position(x, y);

                    if (x == 0 || x == tiles.GetLength(0) - 1 || y == 0 || y == tiles.GetLength(1) - 1)
                    {
                        tiles[x, y] = CreateTile(TileType.Wall, position);
                    }
                    else
                    {
                        tiles[x, y] = CreateTile(TileType.Empty, position);
                    }
                }
            }

        }

        public void SwopTiles(Tile Swop1, Tile Swop2)
        {
            Position temp = Swop1.Pos;
            Position temp2 = Swop2.Pos;



            tiles[temp.xCord, temp.yCord] = Swop2;
            tiles[temp2.xCord, temp2.yCord] = Swop1;

            Swop1.Pos = temp2;
            Swop2.Pos = temp;

        }



        public override string ToString()
        {
            string print = "";

            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    print += tiles[i, j].Display;
                }
                print += "\n";
            }

            return print;
        }


        private Position GetRandomEmptyPosition()
        {


            Random randomNum = new Random();

            int rEmptyX = randomNum.Next(1, width - 1);
            int rEmptyY = randomNum.Next(1, height - 1);


            //Position Check = new Position(rEmptyX, rEmptyY);

           // if (Check ==  
            

            return new Position(rEmptyX, rEmptyY);


        }

        public HeroTile heroTile
        {
            get { return Hero; }
            set { Hero = value; }
        }


        public enum Direction
        {
            up,
            Right,
            Down,
            Left,
            None,

         
        }
    }
}
