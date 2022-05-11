namespace DungeonExplorer
{
    public class World
    {
        public int[,] IslandMap { get; private set; }

        public World(int[,] islandMap)
        {
            IslandMap = islandMap;
        }

    }
    
    
}