using System;
using State;
using UnityEngine;

public class SceneContoller : Controller
{
    public enum SceneState
    {
        TitleScene,
        GameScene,
    }
    
    public StateMachine<SceneState, SceneContoller> SceneStateMachine { get; private set; }

    private void Start()
    {
        SceneStateMachine = new();
        SceneStateMachine.Init(this);
        SceneStateMachine.AddState(SceneState.TitleScene, new TitleSceneState());
        SceneStateMachine.AddState(SceneState.GameScene, new GameSceneState());
        
        SceneStateMachine.ChangeState(SceneState.GameScene);
    }
}
