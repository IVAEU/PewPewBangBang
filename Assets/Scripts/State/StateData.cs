using UnityEngine;

namespace State
{
    public abstract class StateData<T> : ScriptableObject, IState<T> where T : Controller
    {
        public abstract bool IsPlayable(T controller);
        public abstract void OnEnter(T controller);
        public abstract void OnProcessing(T controller);
        public abstract void OnExit(T controller);
    }
}
