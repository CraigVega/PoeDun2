using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeDun
{
    class GameEngine
    {
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
            //return $"GameEngine: {numLevels} levels, Current Level Size: {width}x{height}";
            return currentLevel.ToString();
        }
        
    }


}