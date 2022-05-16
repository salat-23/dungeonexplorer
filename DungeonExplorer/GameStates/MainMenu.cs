using System;
using System.Media;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class MainMenu : GameState
    {
        private SelectionBox menuBox;
        public MainMenu(DungeonExplorer screen) : base(screen)
        {
            List<SelectionBoxButton> buttons = new List<SelectionBoxButton>();
            buttons.Add(new SelectionBoxButton("Big map", "BM"));
            buttons.Add(new SelectionBoxButton("New game", "NG"));
            buttons.Add(new SelectionBoxButton("Options", "OP"));
            buttons.Add(new SelectionBoxButton("Exit", "EX"));
            menuBox = new SelectionBox(buttons, 20, 10);
            menuBox.Selector = "=>";
        }
        public override void Update(float elapsed)
        {

            if (Screen.IsJustPressed(ConsoleKey.S))
            {
                menuBox.MoveDown();
                Screen.Play("Resources/high-pith-beep.wav");
            }
            if (Screen.IsJustPressed(ConsoleKey.W))
            {
                menuBox.MoveUp();
                Screen.Play("Resources/high-pith-beep.wav");
            }
            /*switch (Screen.GetPressedKey())
            {
                case ConsoleKey.S:
                    menuBox.MoveDown();
                    Screen.Play("Resources/high-pith-beep.wav");
                    break;
                case ConsoleKey.W:
                    menuBox.MoveUp();
                    Screen.Play("Resources/bass-beep.wav");
                    break;

                case ConsoleKey.Enter:
                {
                    switch ((string)menuBox.GetSelected().Metadata)
                    {
                        case "NG":
                            Screen.State = new NewGame(Screen);
                            return;
                        case "BM":
                            Screen.State = new BigMap(Screen);
                            break;
                    }
                    break;
                }
            }*/
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