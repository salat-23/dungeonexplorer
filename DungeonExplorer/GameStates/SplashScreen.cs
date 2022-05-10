using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class SplashScreen : GameState
    {
        private SelectionBox menuBox;
        public SplashScreen(Screen screen) : base(screen)
        {
            List<SelectionBoxButton> buttons = new List<SelectionBoxButton>();
            buttons.Add(new SelectionBoxButton("New game", "NG"));
            buttons.Add(new SelectionBoxButton("Options", "OP"));
            buttons.Add(new SelectionBoxButton("Exit", "EX"));
            menuBox = new SelectionBox(buttons, 20, 10);
            menuBox.Selector = "=>";
        }
        public override void Update(float elapsed)
        {
            switch (Screen.GetPressedKey())
            {
                case ConsoleKey.S:
                    menuBox.MoveDown();
                    break;
                case ConsoleKey.W:
                    menuBox.MoveUp();
                    break;
            }
            
            
            
        }

        public override void Display()
        {
            Screen.Draw("Game by salat23", 4, 2);
            Screen.Draw("Dungeon Explorer", 30, 10);
            Screen.DrawRect(")()(", 29, 9, 18, 3);
            Screen.Draw(menuBox, 33, 13);
            Screen.DrawRect("*", 0, 0, 80, 25);
        }

        
    }

    

    
}