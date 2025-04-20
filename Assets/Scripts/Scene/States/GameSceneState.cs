using UnityEngine;
using State;


public class GameSceneState : IState<SceneContoller>
{
    public void OnEnter(SceneContoller controller)
    {
        PoolManager.Instance.CreateObject<PlayerController>(new Vector2(0, 0));
    }

    public void OnProcessing(SceneContoller controller)
    {
        
    }

    public void OnExit(SceneContoller controller)
    {
        
    }
}
