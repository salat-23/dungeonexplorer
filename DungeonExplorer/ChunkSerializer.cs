using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DungeonExplorer
{
    public class ChunkSerializer
    {
        public static void Serialize(Chunk2 chunk, Vector2Int position)
        {
            string chunkFileName = $"./chunks/{position.X}-{position.Y}";
            
            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(chunkFileName, FileMode.Create, FileAccess.Write);
            
            formatter.Serialize(stream, chunk);
            stream.Close();
        }

        public static Chunk2 GetChunk(int x, int y)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream($"./chunks/{x}-{y}", FileMode.Open, FileAccess.Read);

            Chunk2 chunk = (Chunk2)formatter.Deserialize(stream);
            stream.Close();
            return chunk;
        }
    }
}