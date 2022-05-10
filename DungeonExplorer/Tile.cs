namespace DungeonExplorer
{
    public class Tile
    {
        public enum TileType
        {
            FLOOR,
            GRASS,
            WALL
        }
        public TileType Type { get; }
        
        public Tile(TileType type)
        {
            Type = type;
        }
    }
}