namespace DungeonExplorer
{
    public class Chunk
    {
       
        public string Name { get; private set; }
        public LocationType Type { get; private set; }

        public Chunk(LocationType type)
        {
                
        }
        
        

    }

    public enum LocationType
    {
        WOODS,
        PLAIN,
        DESERT,
        MOUNTAINS,
        BEACH
    }
}