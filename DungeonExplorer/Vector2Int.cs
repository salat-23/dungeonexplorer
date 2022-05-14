using System;
using System.Runtime.CompilerServices;

namespace DungeonExplorer
{
    [Serializable]
    public class Vector2Int
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public static Vector2Int operator +(Vector2Int firstVector, Vector2Int secondVector)
        {
            return new Vector2Int(firstVector.X + secondVector.X, firstVector.Y + secondVector.Y);
        }

        public static Vector2Int operator -(Vector2Int firstVector, Vector2Int secondVector)
        {
            return new Vector2Int(firstVector.X - secondVector.X, firstVector.Y - secondVector.Y);
        }
        
        public static Vector2Int operator *(Vector2Int firstVector, Vector2Int secondVector)
        {
            return new Vector2Int(firstVector.X * secondVector.X, firstVector.Y * secondVector.Y);
        }
        
    }
}