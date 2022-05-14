using System;

namespace DungeonExplorer
{
    [Serializable]
    public class Chunk2
    {

        public Tile[,] Tiles { get; }
        
        public Vector2Int Position { get; set; }
        public int Size { get; }
        
        public Chunk2(Tile[,] tiles, int size, Vector2Int position)
        {
            Position = position;
            Tiles = tiles;
            Size = size;
        }
    }
}