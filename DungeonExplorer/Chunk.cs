namespace DungeonExplorer
{
    public class Chunk
    {
        private const int DEFAULT_SIZE = 100;
        public string Name { get; private set; }
        public LocationType Type { get; private set; }
        public Tile[] Tiles { get; private set; }

        public Chunk(LocationType type)
        {
            //Tiles = new Tile[DEFAULT_SIZE * DEFAULT_SIZE];
            Type = type;
            Name = "Test chunk";
        }
    }

    public enum LocationType
    { 
        WOODS,
        PLAIN,
        HILLS,
        MOUNTAINS,
        BEACH,
        OCEAN
    }
}