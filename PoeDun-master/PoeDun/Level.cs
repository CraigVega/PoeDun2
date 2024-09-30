using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    public class Level
    {
       
        int width;
        int height;

        private Tile[,] tiles;

        private int Width
        { 
            get {  return width; }
            set {  width = value; }
        
        }

        private int Height
        {
           get { return height; }
            set { height = value; }

        }

        private HeroTile heroTile; 
       
        public Level(int width, int height, HeroTile heroTile = null) // constructor of level class that now also contains HeroTile
        {
            this.width = width;
            this.height = height;

            tiles = new Tile[width, height]; 

            InitialiseTiles();

            Random X = new Random();
            int HeroX = X.Next(0, Width);
            Random Y = new Random();
            int HeroY = Y.Next(0, Height);

            if (heroTile != null )
            {
                CreateTile(TileType.Hero, HeroX, HeroY);

            }
            else if (heroTile == null) 
            {



            }


        }

        enum TileType
        {
            Empty,
            Wall,
            Hero, // added Hero to enum 
        }

        // property to expose the tiles array
        public Tile[,] Tiles
        {
            get { return tiles; }
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

                case TileType.Hero:
                    tile = new HeroTile(position); // added case for HeroTile 
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
                    tile = new HeroTile(new Position(x, y)); // added case for HeroTile 
                    break;

                default:
                    tile = null;
                    break;
            }

            tiles[x, y] = tile;
            return tiles[x, y];
        }

        public void InitialiseTiles ()
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


        private Position GetRandomEmptyPosition()
        {
           Random random = new Random(); // makes a random object to generate random numbers
            int rows = tiles.GetLength(0); // to get the number of rows 
            int cols = tiles.GetLength(1); // to get the number of columns 

            int row, col; // variables to store the randomly selected row and colum
            do
            {
                row = random.Next(rows);  // to pick a random row
                col = random.Next(cols); // to pick a random column
            }
            while (tiles[row, col] != null); // keeps picking until it finds an empty tile (null)

            return new Position(row, col); // returns the position of the empty tile
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

    }
}
