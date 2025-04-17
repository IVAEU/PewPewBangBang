namespace State
{
    public interface IState<in T> where T : Controller
    {
        public bool IsPlayable(T controller);
        public void OnEnter(T controller);
        public void OnProcessing(T controller);
        public void OnExit(T controller);
    }
}
