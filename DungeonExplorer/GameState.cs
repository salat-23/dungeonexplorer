namespace DungeonExplorer
{

    public abstract class GameState 
    {
        protected DungeonExplorer Screen { get; }

        public GameState(DungeonExplorer screen)
        {
            Screen = screen;
        }

        public abstract void Update(float elapsed);


        public abstract void Display();
    }
}