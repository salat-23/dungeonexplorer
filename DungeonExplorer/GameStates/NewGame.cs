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
        private int displayedNum = 1;

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
                case ConsoleKey.UpArrow:
                    displayedNum++;
                    break;
                case ConsoleKey.DownArrow:
                    displayedNum--;
                    break;
            }
        }

        public override void Display()
        {
            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 80; x++)
                {
                    Screen.Draw(world.Chunks[x, y], x, y);
                }
            }
        }

       
    }
}