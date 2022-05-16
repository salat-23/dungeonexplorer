using System;

namespace DungeonExplorer
{
    [Serializable]
    public class Chunk2
    {

        public Tile[,] Tiles { get; }
        public int Size { get; }
        
        public Chunk2(Tile[,] tiles, int size)
        {
            Tiles = tiles;
            Size = size;
        }

        public static Chunk2 Empty(int size)
        {
            Tile[,] tiles = new Tile[size, size];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    tiles[x, y] = new Tile(Tile.TileType.WATER, 0f);
                }
            }
            return new Chunk2(tiles, size);
        }
    }
}