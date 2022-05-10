using System.Collections.Generic;

namespace DungeonExplorer
{
    public class SelectionBox
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int SelectedIndex { get; private set; }
        public List<SelectionBoxButton> Buttons { get; private set; }
        public int Gap { get; set; }
        
        public bool IsVisible { get; set; }
        public string Selector { get; set; }
        public char Border { get; set; }
        public bool IsBordered { get; set; }

        public SelectionBox(List<SelectionBoxButton> buttons, int width, int height)
        {
            Buttons = buttons;
            Height = height;
            Width = width;
            Gap = 0;
            Selector = ">";
            Border = '#';
            IsBordered = true;
        }

        public void MoveDown()
        {
            SelectedIndex++;
            if (SelectedIndex > Buttons.Count - 1) SelectedIndex = 0;
            if (SelectedIndex < 0) SelectedIndex = Buttons.Count - 1;
        }

        public void MoveUp()
        {
            SelectedIndex--;
            if (SelectedIndex > Buttons.Count - 1) SelectedIndex = 0;
            if (SelectedIndex < 0) SelectedIndex = Buttons.Count - 1;
        }

        public SelectionBoxButton GetSelected()
        {
            return Buttons[SelectedIndex];
        }
        
    } 
}