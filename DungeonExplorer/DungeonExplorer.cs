namespace DungeonExplorer
{
    public class DungeonExplorer : Game
    {

        public GameState State { get; set; }

        public DungeonExplorer() : base(80, 25)
        {
            State = new TestState(this);
        }

        protected override void Update(float elapsed)
        {
            State.Update(elapsed);
            State.Display();
        }
    }
}