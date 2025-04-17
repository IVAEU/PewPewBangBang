using UnityEngine;
using State;

namespace State
{
    [System.Serializable]
    public class Context<TController, TStateData> 
        where TController : Controller 
        where TStateData : StateData<TController>
    {
        public TStateData CurrentState;
        public TStateData[] States;
        
        protected TController Controller;

        public void Init<T>(T c) where T : TController
        {
            Controller = c;
        }
        
        public void TransitionToState(TStateData state) 
        {
            if (CurrentState)
                CurrentState.OnExit(Controller);
            CurrentState = state;
            CurrentState.OnEnter(Controller);
        }
        
        public void SearchNextState(TController controller)
        {
            foreach (var state in States)
            {
                if (state.IsPlayable(controller))
                {
                    TransitionToState(state);
                    return;
                }
            }
        
            TransitionToState(States[^1]);
        }
    }
}
