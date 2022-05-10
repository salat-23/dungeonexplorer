namespace DungeonExplorer
{
    public interface IGameState
    {
        protected Screen Screen { get; }
        public void Update(float elapsed);

        public void Display();
    }

    public abstract class GameState : IGameState
    {
        protected Screen Screen { get; }

        public GameState(Screen screen)
        {
            Screen = screen;
        }

        Screen IGameState.Screen => Screen;

        public abstract void Update(float elapsed);


        public abstract void Display();
    }
}