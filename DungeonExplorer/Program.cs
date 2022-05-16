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