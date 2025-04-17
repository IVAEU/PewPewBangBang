using System.Collections.Generic;
using UnityEngine;
using State;

namespace State
{
    public enum SubStateType
    {
        Locomotion, //이동
        Behavior //행동
    }

    public enum StateType : uint
    {
        Idle,
        Move,
        Attack,
        Skill
    }
    
    [System.Serializable]
    public class Context<TController> where TController : IController 
    {
        public Dictionary<SubStateType, IState<TController>> CurrentState = new();
        public Dictionary<SubStateType, Dictionary<StateType, IState<TController>>> States = new();
        
        protected TController Controller;

        public void Init<T>(T c) where T : TController
        {
            Controller = c;
        }

        public void AddState(SubStateType subState, StateType type, IState<TController> state)
        {
            if (States.TryGetValue(subState, out var detailSubState))
            {
                if (detailSubState.TryGetValue(type, out _))
                {
                    detailSubState[type] = state;
                }
                else
                {
                    detailSubState.Add(type, state);
                }
            }
            else
            {
                States.Add(subState, new Dictionary<StateType, IState<TController>>());
                States[subState].Add(type, state);
            }
        }
        
        public void ChangeState(SubStateType subState, StateType type) 
        {
            if (CurrentState.TryGetValue(subState, out _))
            {
                Debug.Log($"State Changed. {subState}: {CurrentState[subState]} -> {States[subState][type]}");
                CurrentState[subState].OnExit(Controller);
                CurrentState[subState] = States[subState][type];
            }
            else
            {
                Debug.Log($"State Setted. {subState}: {States[subState][type]}");
                CurrentState.Add(subState, States[subState][type]);
            }
            
            CurrentState[subState].OnEnter(Controller);
        }
    }
}
