using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public abstract class Game : Screen
    {
        const float LowLimit = 0.0167f;          // Keep At/Below 60fps
        const float HighLimit = 0.1f;            // Keep At/Above 10fps
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
                    Console.Clear();
                    accumulaterClearTimer = 0;
                }
                Clear();
                Update(deltaTime);
                Refresh();
                lastTime = currentTime;
            }
        }
        protected abstract void Update(float elapsed);
    }
}