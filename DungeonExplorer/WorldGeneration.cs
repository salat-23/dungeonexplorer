using System;
using DungeonExplorer.CellularAutomata;

namespace DungeonExplorer
{
    public class WorldGeneration
    {
        private World world;
        private int[,] fieldIslandLand;
        private int[,] fieldBiome;
        private RuleSet islandGenerationLife;
        private RuleSet biomeGenerationLife;
        public int Seed { get; private set; }

        public WorldGeneration(int seed)
        {
            Seed = seed;
        }

        public World GenerateWorld()
        {
            InitializeGroundField();
            InitializeBiomeField();
            world = new World(fieldIslandLand);
            return world;
        }

        private void InitializeBiomeField()
        {
            SimplexNoise.Noise.Seed = Seed;
            float[,] simplexGenerated = SimplexNoise.Noise.Calc2D(80, 25, 1f);
            
        }
        
        private void InitializeRuleSet(int[,] field, int maxX, int maxY)
        {
            islandGenerationLife = new SalatIslandAutomata(field, maxX, maxY, Seed);
        }

        
        private void InitializeGroundField()
        {
            fieldIslandLand = new int[80, 25];
            
            int radius = 3;
            int steps = 18;
            int xStart = 30;
            int yStart = 13;
            int randomAreaSize = 3;
            
            
            int randomY = new Random(Seed).Next(yStart, yStart + randomAreaSize);
            int randomX = new Random(Seed).Next(xStart, xStart + randomAreaSize);
            for (int y = randomY - radius; y < randomY + radius; y++)
            {
                for (int x = randomX - radius; x < randomX + radius; x++)
                {
                    if (x is >= 0 and < 80 && y is >= 0 and < 25)
                        fieldIslandLand[x, y] = 1;
                }
            }

            InitializeRuleSet(fieldIslandLand, 80, 25);
            for (int i = 0; i < steps; i++)
            {
                islandGenerationLife.GetNewState();
            }

            for (int x = 0; x < 80; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    if (fieldIslandLand[x, y] > 0)
                    {
                        bool isLastVertical = true;
                        for (int verY = y; verY < 25; verY++)
                        {
                            if (fieldIslandLand[x, verY] > 0) isLastVertical = false;
                            break;
                        }

                        if (!isLastVertical)
                        {
                            int lastVerticalY = 0;

                            for (int bottom = 24; bottom >= 0; bottom--)
                            {
                                if (fieldIslandLand[x, bottom] > 0)
                                {
                                    lastVerticalY = bottom;
                                    break;
                                }
                            }

                            for (int curs = y; curs < lastVerticalY; curs++)
                            {
                                fieldIslandLand[x, curs] = 1;
                            }

                            break;
                        }
                    }
                }
            }

            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 80; x++)
                {
                    if (fieldIslandLand[x, y] > 0)
                    {
                        bool isLastHorizontal = true;
                        for (int horX = x; horX < 80; horX++)
                        {
                            if (fieldIslandLand[horX, y] > 0) isLastHorizontal = false;
                            break;
                        }

                        if (!isLastHorizontal)
                        {
                            int lastHorizontalX = 80;

                            for (int right = 79; right >= 0; right--)
                            {
                                if (fieldIslandLand[right, y] > 0)
                                {
                                    lastHorizontalX = right;
                                    break;
                                }
                            }

                            for (int curs = x; curs <= lastHorizontalX; curs++)
                            {
                                fieldIslandLand[curs, y] = 1;
                            }

                            break;
                        }
                    }
                }
            }
        }
    }
}