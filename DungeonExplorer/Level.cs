using System;

namespace DungeonExplorer
{
    public class Level
    {
        public int CurrentLevel { get; private set; }
        public int CurrentExp { get; private set; }

        public Level(int level)
        {
            CurrentLevel = level;
            CurrentExp = 0;
        }

        public Level(int level, int exp)
        {
            CurrentLevel = level;
            CurrentExp = exp;
        }
        public static int NextLevel(int level)
        {
            return (int)Math.Round((4 * (level ^ 3)) / 5d);
        }

        public bool Gain(int exp)
        {
            CurrentExp += exp;
            if (CurrentExp > NextLevel(CurrentLevel))
            {
                CurrentLevel++;
                CurrentExp = 0;
                return true;
            }
            return false;
        }
    }
}