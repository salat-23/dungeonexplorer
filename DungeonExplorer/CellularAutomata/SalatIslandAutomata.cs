using System;

namespace DungeonExplorer.CellularAutomata
{
    public class SalatIslandAutomata : RuleSet
    {

        private int seed;
        public SalatIslandAutomata(int[,] field, int maxX, int maxY, int seed) : base(field, maxX, maxY)
        {
            this.seed = seed;
        }

        protected override int[,] NewStateAlgorithm()
        {
            int[,] field2 = new int[maxX, maxY];
            Random random = new Random(seed);
            for (int y = 0; y < maxY; y++)  
            {  
                for (int x = 0; x < maxX; x++)
                {
                    int neighbors = GetNumberOfNeighbors(x, y);  
                    if (neighbors == 2 && field[x, y] == 0 && random.Next(0, 10) > 2)
                    {
                        // cell is born.  
                        field2[x, y] = 1;  
                        continue;  
                    }  
  
                    if (neighbors == 3)  
                    {  
                        // cell continues.  
                        field2[x, y] = field[x, y] + 1;  
                        continue;  
                    }  
  
                    // cell dies.  
                    //if (field[x, y] < 3 && field[x, y] > 8)
                        //field2[x, y] = 0;  
                }  
            }  
  
            return field2; 
        }
    }
}