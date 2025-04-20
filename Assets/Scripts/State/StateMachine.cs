using System.Collections.Generic;
using UnityEngine;
using State;

namespace State
{
    [System.Serializable]
    public class StateMachine<TEnum, TController> where TEnum: System.Enum where TController : Controller
    {
        public IState<TController> CurrentState;
        public Dictionary<TEnum, IState<TController>> States = new();
        
        protected TController Controller;

        public void Init<T>(T c) where T : TController
        {
            Controller = c;
        }

        public void AddState(TEnum type, IState<TController> state)
        {
            if (States.TryGetValue(type, out _))
            {
                States[type] = state;
            }
            else
            {
                States.Add(type, state);
            }
        }
        
        public void ChangeState(TEnum type)
        {
            if (CurrentState != null)
            {
                Debug.Log($"State Changed. {CurrentState} -> {States[type]}");
                CurrentState.OnExit(Controller);
                CurrentState = States[type];
            }
            else
            {
                Debug.Log($"State Setted. {States[type]}");
                CurrentState = States[type];
            }
            
            Debug.Log($"State = {CurrentState}");
            CurrentState.OnEnter(Controller);
        }
    }
}
