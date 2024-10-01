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

        int width;
        int height;
        HeroTile Hero;

        private PickupTile[] pickups; // array to store pickups in the level

        public Level(int width, int height, int numberOfPickups, HeroTile Hero = null) // added numberOfPickups to constructor
        {
            this.width = width;
            this.height = height;

            tiles = new Tile[width, height];  // No need for Tile[,] tiles as we already declared it above in the field
            InitialiseTiles();

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
            CreateTile(TileType.Exit, exitPos);  // creates and place ExitTile

            for (int i = 0; i < numberOfPickups; i++) 
            { 
            Position pickupPos = GetRandomEmptyPosition();
            pickups[i] = (PickupTile)CreateTile(TileType.Pickup, pickupPos);
            }
        }


        enum TileType
        {
            Empty,
            Wall,
            Hero, // added Hero to enum 
            Exit, // added Exit to enum
            Pickup, // added Exit to enum
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
                case TileType.Pickup: // added for PickupTile
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
                case TileType.Pickup:
                    tile = new HealthPickupTile(new Position(x, y));
                    break;

                default:
                    tile = null;
                    break;
            }

            tiles[x, y] = tile;
            return tiles[x, y];
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


            //Position HeroXY = new Position(rEmptyX, rEmptyY);

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
