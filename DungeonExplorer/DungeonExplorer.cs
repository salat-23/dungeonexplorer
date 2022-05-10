namespace DungeonExplorer
{
    public class DungeonExplorer : Game
    {

        private GameState state;

        public DungeonExplorer() : base(80, 25)
        {
            state = new SplashScreen(this);
        }

        protected override void Update(float elapsed)
        {
            state.Update(elapsed);
            state.Display();
        }
    }
}