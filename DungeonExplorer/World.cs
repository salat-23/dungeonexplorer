namespace DungeonExplorer
{
    public class World
    {
        private Vector2Int size = new Vector2Int(10, 10);
        private Location[] locations;
        public int CurrentLocation { get; private set; }
        
        public World()
        {
            locations = new Location[size.X * size.Y];
            for (int i = 0; i < locations.Length; i++)
            {
                locations[i] = new Location();
            }

            CurrentLocation = 0;
        }
        
    }
    
}