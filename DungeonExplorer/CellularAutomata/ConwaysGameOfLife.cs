namespace DungeonExplorer.CellularAutomata
{
    public class ConwaysGameOfLife : RuleSet
    {
        public ConwaysGameOfLife(int[,] field, int maxX, int maxY) : base(field, maxX, maxY)
        {
        }

        protected override int[,] NewStateAlgorithm()
        {
            int[,] field2 = new int[maxX, maxY];  
  
            for (int y = 0; y < maxY; y++)  
            {  
                for (int x = 0; x < maxX; x++)  
                {  
                    int neighbors = GetNumberOfNeighbors(x, y);  
                    if (neighbors == 3)  
                    {  
                        // cell is born.  
                        field2[x, y] = 1;  
                        continue;  
                    }  
  
                    if (neighbors == 2)  
                    {  
                        // cell continues.  
                        field2[x, y] = field[x, y];  
                        continue;  
                    }  
  
                    // cell dies.  
                    field2[x, y] = 0;  
                }  
            }  
  
            return field2;  
        }
    }
}