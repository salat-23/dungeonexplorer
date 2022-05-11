using System;
using System.IO;
using System.Linq;
using System.Text;

namespace DungeonExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            SimplexNoise.Noise.Seed = 1337;
            DungeonExplorer game = new DungeonExplorer();
            game.Start();
        }
    }
}