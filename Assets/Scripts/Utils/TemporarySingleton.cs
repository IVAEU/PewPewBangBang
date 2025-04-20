namespace Utils
{
    public class TemporarySingleton<T> : Singleton<T> where T : Singleton<T>
    {
        protected override void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
