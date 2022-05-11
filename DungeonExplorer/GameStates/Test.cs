namespace DungeonExplorer
{
    public class Test : GameState
    {
        public Test(DungeonExplorer screen) : base(screen) { }

        public override void Update(float elapsed)
        {
            
        }

        public override void Display()
        {
            Screen.Draw("TEST", 5, 5);
        }
    }
}