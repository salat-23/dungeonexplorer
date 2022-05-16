using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DungeonExplorer
{
    public class Screen
    {
        private int Width { get; }
        private int Height { get; }

        private HashSet<ConsoleKey> holdedKeys;

        public Screen(int width, int height)
        {
            Height = height;
            Width = width;
            holdedKeys = new HashSet<ConsoleKey>();
            FastConsole.Init(width, height);
            Clear();
        }

        public bool IsPressed(ConsoleKey key)
        {
            bool isPressed = FastConsole.IsPressed(key);
            return isPressed;
        }
        
        public bool IsJustPressed(ConsoleKey key)
        {
            bool isPressed = FastConsole.IsJustPressed(key);
            return isPressed;
        }

        public ConsoleKey? GetPressedKey()
        {
            if (Console.KeyAvailable)
            {
                return Console.ReadKey(true).Key;
            }

            return null;
        }

        public void Clear()
        {
            FastConsole.Clear();
        }

        private int[] GetSlice(SelectionBoxButton[] array, int selectedIndex, int capacity)
        {
            if (capacity > array.Length) capacity = array.Length;
            int offset = capacity % 2 == 0 ? capacity / 2 : (capacity - 1) / 2;
            int startIndex = selectedIndex - offset;
            while (startIndex + capacity > array.Length)
            {
                startIndex--;
            }
            while (startIndex < 0)
            {
                startIndex++;
            }

            int[] result = new int[capacity];
            int resultIndex = 0;
            for (int i = startIndex; i < startIndex + capacity; i++)
            {
                result[resultIndex] = i;
                resultIndex++;
            }

            return result;
        }
        public void Draw(SelectionBox box, int x, int y)
        {
            int selected = box.SelectedIndex;
            int takenChars = box.Buttons.Count + box.Buttons.Count * box.Gap - box.Gap;
            int ableToDraw = takenChars > box.Height ? (int)Math.Ceiling(takenChars / (float)box.Height) : takenChars; 
            int[] drawingIndexes = GetSlice(box.Buttons.ToArray(), selected, ableToDraw);

            int drawed = 0;
            foreach (var index in drawingIndexes)
            {
                int xdraw = x;
                int ydraw = y + drawed + (box.Gap * drawed /*- (drawingIndexes[^1] == index ? box.Gap : 0)*/);
                if (selected == index)
                {
                    xdraw+=box.Selector.Length;
                    // ^1 means first index from end
                    Draw(box.Selector, x, ydraw);
                }
                Draw(box.Buttons[index].Text, xdraw, ydraw);
                drawed++;
            }
        }
        public void Draw(string text, int x, int y, ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
        {
            if (y > Height - 1 || y < 0) return;
            foreach (var character in text)
            {
                if (!(x > Width - 1 || x < 0))
                    FastConsole.Draw(x, y, character, foreground, background);
                x++;
            }
        }

        public void Draw(char text, int x, int y, ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
        {
            if (y > Height - 1 || y < 0) return;
            if (!(x > Width - 1 || x < 0))
                FastConsole.Draw(x, y, text, foreground, background);
        }

        public void DrawRect(string charset, int x, int y, int sizeX, int sizeY, ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
        {
            int maxIndex = charset.Length - 1;
            int strIndex = 0;
            for (int iy = 0; iy < sizeY; iy++)
            {
                for (int ix = 0; ix < sizeX; ix++)
                {
                    if (ix == 0 || ix == sizeX - 1 || iy == 0 || iy == sizeY - 1)
                    {
                        Draw(charset[strIndex], x + ix, y + iy, foreground, background);
                        strIndex++;
                        if (strIndex > maxIndex) strIndex = 0;
                    }
                }
            }
        }
        
        public void Play(string sound)
        {
            FastConsole.Play(sound);
        }

        public void Refresh()
        {
            for (int i = 0; i < holdedKeys.Count; i++)
            {
                
            }
            FastConsole.Render();
        }
    } 
}