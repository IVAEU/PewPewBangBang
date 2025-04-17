namespace State
{
    public interface IState<in T> where T : IController
    {
        public void OnEnter(T controller);
        public void OnProcessing(T controller);
        public void OnExit(T controller);
    }
}
