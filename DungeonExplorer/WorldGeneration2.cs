using System;

namespace DungeonExplorer
{
    public class WorldGeneration2
    {
        private static readonly Vector2Int DefaultSize = new(1024, 1024);

        private Vector2Int size;
        private FastNoiseLite noiseGenerator;
        private Random random;

        public WorldGeneration2(int seed)
        {
            size = DefaultSize;
            noiseGenerator = new FastNoiseLite(seed);
            random = new Random(seed);
        }

        public WorldGeneration2(int seed, Vector2Int size)
        {
            this.size = size;
            noiseGenerator = new FastNoiseLite(seed);
            random = new Random(seed);
        }

        public World2 Generate()
        {
            noiseGenerator.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
            noiseGenerator.SetFrequency(0.005f);
            noiseGenerator.SetFractalOctaves(1);
            noiseGenerator.SetFractalLacunarity(1.3f);
            noiseGenerator.SetFractalGain(0.6f);
            
            float[,] perlinMap = new float[size.X, size.Y];
            float offset = (float)random.NextDouble();


            for (int y = 0; y < size.Y; y++)
            {
                for (int x = 0; x < size.X; x++)
                {
                    perlinMap[x, y] = noiseGenerator.GetNoise(x + offset, y + offset);
                }
            }

            int chunkSize = 128;
            int chunkCountX, chunkCountY = 0;
            for (int chunkY = 0; chunkY < size.Y; chunkY += chunkSize)
            {
                chunkCountX = 0;
                for (int chunkX = 0; chunkX < size.X; chunkX += chunkSize)
                {
                    Tile[,] tiles = new Tile[chunkSize, chunkSize];
                    for (int y = 0; y < chunkSize; y++)
                    {
                        for (int x = 0; x < chunkSize; x++)
                        {
                            float nx = 2 * x / DefaultSize.X - 1;
                            float ny = 2 * y / DefaultSize.Y - 1;
                            float d = 1f - (1f - MathF.Pow(nx, 2)) * (1f - MathF.Pow(ny, 2));
                            float num = perlinMap[chunkX + x, chunkY + y];

                            float elevation = (num + (1 - d)) / 2;
                            
                            
                            Tile.TileType type = Tile.TileType.WATER;
                            if (num > 0)
                                type = Tile.TileType.SAND;
                            if (num > 0.3)
                                type = Tile.TileType.GRASS;
                            if (num > 0.7)
                                type = Tile.TileType.STONE;
                            tiles[x, y] = new Tile(type, elevation);
                        }
                    }
                    Chunk2 chunk = new Chunk2(tiles, chunkSize, new Vector2Int(chunkCountX, chunkCountY));
                    ChunkSerializer.Serialize(chunk);
                    chunkCountX++;
                }
                chunkCountY++;
            }
            return new World2(DefaultSize);
        }
    }
}