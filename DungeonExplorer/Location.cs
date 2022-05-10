namespace DungeonExplorer
{
    public class Location
    {
        private const int size = 300;

        public string Name { get; private set; }

        private int difficultyIndex;

        private Tile[] tiles;

        public Location()
        {
            tiles = new Tile[300 * 300];
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = new Tile(Tile.TileType.GRASS);
            }
        }
        
        

    }
}