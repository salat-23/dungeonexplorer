namespace DungeonExplorer
{
    public class World
    {
        public Chunk[,] Chunks { get; private set; }

        private int sizeX, sizeY;

        public World(int[,] islandMap, double[,] biomeMap, int sizeX, int sizeY)
        {
            this.sizeX = sizeX; 
            this.sizeY = sizeY; 
            Chunks = new Chunk[sizeX, sizeY];
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    if (islandMap[x, y] == 0)
                    {
                        Chunks[x, y] = new Chunk(LocationType.OCEAN);
                        continue;
                    }
                    double biomeNum = biomeMap[x, y];
                    LocationType type = LocationType.PLAIN;
                    if (biomeNum > 1.3) type = LocationType.WOODS;
                    if (biomeNum > 1.6) type = LocationType.HILLS;
                    if (biomeNum > 1.8) type = LocationType.MOUNTAINS;
                    if (IsBeachChunk(x, y, islandMap)) type = LocationType.BEACH;
                    if (islandMap[x, y] == 0) type = LocationType.OCEAN;
                    Chunks[x, y] = new Chunk(type);
                }
            }

        }

        private bool IsBeachChunk(int x, int y, int[,] map)
        {
            for (int inY = y - 1; inY <= y + 1; inY++)
            {
                for (int inX = x - 1; inX <= x + 1; inX++)
                {
                    if (inY > 0 && inY < sizeY && inX > 0 && inX < sizeX)
                    {
                        if (map[inX, inY] <= 0) return true;
                    }
                }
            }

            return false;
        }

    }
    
    
}