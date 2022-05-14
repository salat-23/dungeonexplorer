using System;

namespace DungeonExplorer
{
    [Serializable]
    public class World2
    {
        public Vector2Int Size { get; }

        public World2(Vector2Int size)
        {
            Size = size;
        }
    }
}