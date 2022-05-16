using System;

namespace DungeonExplorer
{
    [Serializable]
    public class World2
    {
        public Vector2Int Size { get; }
        public int ChunkSize { get; }
        public Chunk2[,] LoadedChunks { get; }

        private Vector2Int PreviousLoadPosition;

        public World2(Vector2Int size, int chunkSize)
        {
            Size = size;
            ChunkSize = chunkSize;
            LoadedChunks = new Chunk2[3, 3];
            
        }
        
        

        private Chunk2[,] LoadChunks(int x, int y)
        {
            if (x < 0 || y < 0 || x > Size.X - 1 || y > Size.Y - 1) return null;
            Chunk2[,] chunks = new Chunk2[3, 3];
            
            for (int cy = y - ChunkSize; cy < y + ChunkSize; cy++)
            {
                for (int cx = x - ChunkSize; cx < x + ChunkSize; cx++)
                {
                    if (cx < 0 || cy < 0 || cx > Size.X - 1 || cy > Size.Y - 1)
                    {
                        chunks[cx, cy] = Chunk2.Empty(ChunkSize);
                        continue;
                    }
                    int chunkX = cx / ChunkSize;
                    int chunkY = cy / ChunkSize;
                    chunks[cx, cy] = ChunkSerializer.GetChunk(chunkX, chunkY);
                }
            }

            PreviousLoadPosition.X = x;
            PreviousLoadPosition.Y = y;
            return chunks;
        }
    }
}