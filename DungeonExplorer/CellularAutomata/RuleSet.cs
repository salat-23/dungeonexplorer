using System;

namespace DungeonExplorer.CellularAutomata
{
    public abstract class RuleSet
    {
        protected int maxY = 0;
        protected int maxX = 0;
        protected int[,] field;


        protected RuleSet(int[,] field, int maxX, int maxY)
        {
            this.field = field;
            this.maxX = maxX;
            this.maxY = maxY;
        }

        protected int GetNumberOfNeighbors(int x, int y)
        {
            int neighbors = 0;
            int xPos;
            int yPos;
            for (xPos = x - 1; xPos <= x + 1; xPos++)
            {
                for (yPos = y - 1; yPos <= y + 1; yPos++)
                {
                    if (xPos == x && yPos == y) continue;

                    if (xPos < maxX && xPos >= 0 && yPos < maxY && yPos >= 0 && field[xPos, yPos] == 1)
                    {
                        neighbors++;
                    }
                }
            }

            return neighbors;
        }

        public void GetNewState()
        {
            int[,] field2 = NewStateAlgorithm();
            Array.Copy(field2, field, field2.Length);
        }

        protected abstract int[,] NewStateAlgorithm();
    }
}