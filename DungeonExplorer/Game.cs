using System;
using System.Collections.Generic;
using System.Threading;

namespace DungeonExplorer
{
    public abstract class Game : Screen
    {
        const float LowLimit = 0.0167f;          // Keep below 60fps
        const float HighLimit = 0.1f;            // Keep above 10fps
        const float ClearTimerStep = 60f;
        protected Game(int width, int height) : base(width, height) { }
        public void Start()
        {
            bool running = true;
            long lastTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            float accumulaterClearTimer = 0;
            while (true)
            {
                long currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                float deltaTime = (currentTime - lastTime) / 1000f;
                if ( deltaTime < LowLimit )
                    deltaTime = LowLimit;
                else if ( deltaTime > HighLimit )
                    deltaTime = HighLimit;
                accumulaterClearTimer += deltaTime;
                if (accumulaterClearTimer > ClearTimerStep)
                {
                    //Console.Clear();
                    accumulaterClearTimer = 0;
                }
                Clear();
                Update(deltaTime);
                Refresh();
                lastTime = currentTime;
            }
        }
        public void Draw(Chunk chunk, int x, int y)
        {
            char chunkChar = '?';
            switch (chunk.Type)
            {
                case LocationType.PLAIN:
                    chunkChar = '.';
                    break;
                case LocationType.WOODS:
                    chunkChar = '#';
                    break;
                case LocationType.HILLS:
                    chunkChar = '^';
                    break;
                case LocationType.BEACH:
                    chunkChar = '~';
                    break;
                case LocationType.MOUNTAINS:
                    chunkChar = 'A';
                    break;
                case LocationType.OCEAN:
                    chunkChar = ' ';
                    break;
            }
            Draw(chunkChar, x, y);
        }
        protected abstract void Update(float elapsed);
    }
}