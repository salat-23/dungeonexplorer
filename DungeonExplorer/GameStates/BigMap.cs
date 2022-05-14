using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class BigMap : GameState
    {
        private WorldGeneration2 worldGeneration;
        private World2 world;
        private Chunk2 currentChunk;
        private int x = 2, y = 3;
        private float z = 0;
        private String groundTiles = " .,+#%$";
        public BigMap(DungeonExplorer screen) : base(screen)
        {
            worldGeneration = new WorldGeneration2(27575);
            world = worldGeneration.Generate();
            currentChunk = ChunkSerializer.GetChunk(x, y);
        }

        private char GetChar(float num)
        {
            float highBound = 0.6f;

            float step = highBound / groundTiles.Length;
            char res = groundTiles[0];
            for (int i = 0; i < groundTiles.Length; i++)
            {
                if (num > i * step) res = groundTiles[i];
            }

            return res;
        }

        public override void Update(float elapsed)
        {

            ConsoleKey? key = Screen.GetPressedKey();

            if (key != null)
            {
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        x--;
                        break;
                    case ConsoleKey.RightArrow:
                        x++;
                        break;
                    case ConsoleKey.UpArrow:
                        y--;
                        break;
                    case ConsoleKey.DownArrow:
                        y++;
                        break;
                    case ConsoleKey.W:
                        z+=0.01f;
                        break;
                    case ConsoleKey.S:
                        z-=0.01f;
                        break;
                }
                currentChunk = ChunkSerializer.GetChunk(x, y);
            }
        }

        public override void Display()
        {
            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 25; x++)
                {
                    Tile tile = currentChunk.Tiles[x, y];
                    if (tile.Height > z)
                        Screen.Draw(GetChar(tile.Height), x, y);
                }
            }

        }
    }
}