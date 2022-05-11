using System;
using System.Data;
using DungeonExplorer.CellularAutomata;

namespace DungeonExplorer
{
    public class NewGame : GameState
    {
        private WorldGeneration generation;
        private World world;
        private int seed = 25565;

        public NewGame(DungeonExplorer screen) : base(screen)
        {
            generation = new WorldGeneration(seed);
            world = generation.GenerateWorld();
        }

        public override void Update(float elapsed)
        {
            switch (Screen.GetPressedKey())
            {
                case ConsoleKey.W:
                    seed++;
                    generation = new WorldGeneration(seed);
                    world = generation.GenerateWorld();
                    break;
                case ConsoleKey.S:
                    seed--;
                    generation = new WorldGeneration(seed);
                    world = generation.GenerateWorld();
                    break;
            }
        }

        public override void Display()
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    int num = world.IslandMap[j, i];
                    if (num > 0)
                    {
                        char drawable = '.';
                        if (num > 2) drawable = '~';
                        if (num > 4) drawable = '=';
                        if (num > 6) drawable = 'x';
                        if (num > 10) drawable = 'X';
                        Screen.Draw(drawable, j, i);
                    }
                }
            }
        }

       
    }
}