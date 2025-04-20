using System;
using System.Collections.Generic;
using Utils;

namespace Managers
{
    public enum GameEvent
    {
        Player_Shoot,
        Player_Death,
    
        Enemy_Hitted,
        Enemy_Death,
        
        Stage_Start,
        Stage_End,
    }

    public class EventManager : Singleton<EventManager>
    {
        private readonly Dictionary<GameEvent, Action> _gameEvents = new Dictionary<GameEvent, Action>();

        public void SubscribeEvent(GameEvent gameEvent, Action onEvent)
        {
            _gameEvents[gameEvent] += onEvent;
        }

        public void UnsubscribeEvent(GameEvent gameEvent, Action onEvent)
        {
            _gameEvents[gameEvent] -= onEvent;
        }

        public void ProcessEvent(GameEvent gameEvent)
        {
            if(!_gameEvents.ContainsKey(gameEvent)) return;
            _gameEvents[gameEvent]?.Invoke();
        }
    }
}