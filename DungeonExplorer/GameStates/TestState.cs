using System;

namespace DungeonExplorer
{
    public class TestState : GameState
    {
        public TestState(DungeonExplorer screen) : base(screen)
        {
        }

        public override void Update(float elapsed)
        {
            
        }

        public override void Display()
        {
            Screen.DrawRect("Hello", 0, 0, 80, 25);
        }
    }
}