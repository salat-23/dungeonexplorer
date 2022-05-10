using System.Collections.Generic;

namespace DungeonExplorer
{
    public class GameEvent
    {
        public enum EventType
        {
            EXIT
        }

        private EventType Type { get; set; }

        public static bool ContainsOfType(EventType type, List<GameEvent> eventList)
        {
            bool result = false;
            eventList.ForEach(e =>
            {
                if (e.Type == type) result = true;
            });
            return result;
        }
    }
}