using System;

namespace DungeonExplorer
{
    [Serializable]
    public class Tile
    {
        [Serializable]
        public enum TileType
        {
            WATER,
            SAND,
            GRASS,
            STONE
            
        }
        public TileType Type { get; }
        public float Height { get; }
        
        public Tile(TileType type, float f)
        {
            Type = type;
            Height = f;
        }
    }
}