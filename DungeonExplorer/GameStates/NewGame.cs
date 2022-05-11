using System;

namespace DungeonExplorer
{
    public class NewGame : GameState
    {
        private double minNum = 0;
        private PerlinNoise perlinNoise;
        private int x = 20, y = 20;
        public NewGame(DungeonExplorer screen) : base(screen)
        {

            perlinNoise = new PerlinNoise(99);
        }

        public override void Update(float elapsed)
        {
            int step = 1;
            double minNumStep = 0.01f;
            switch (Screen.GetPressedKey())
            {
                case ConsoleKey.W:
                    minNum+=minNumStep;
                    break;
                case ConsoleKey.S:
                    minNum-=minNumStep;
                    if (minNum < 0) minNum = 0;
                    break;
                case ConsoleKey.UpArrow:
                    y -= step;
                    break;
                case ConsoleKey.DownArrow:
                    y += step;
                    break;
                case ConsoleKey.LeftArrow:
                    x -= step;
                    break;
                case ConsoleKey.RightArrow:
                    x += step;
                    break;
            }

            int yscreen = 0;
            for (int i = y; i < y + 25; i++)
            {
                int xscreen = 0;
                for (int j = x; j < x + 80; j++)
                {                   // First octave
                    double number = (perlinNoise.Noise(200 * j, 200 * i, -0.5) + 1) / 2 * 0.7 +
                                    // Second octave
                                    (perlinNoise.Noise(400 * j, 400 * i, 0) + 1) / 2 * 0.2 +
                                    // Third octave
                                    (perlinNoise.Noise(800 * j, 800 * i, +0.5) + 1) / 2 * 0.1;

                    if (number >= minNum)
                    {
                        Screen.Draw("#", xscreen, yscreen);
                    }
                    xscreen++;
                }

                yscreen++;
            }
        }

        public override void Display()
        {
            
        }
    }
}