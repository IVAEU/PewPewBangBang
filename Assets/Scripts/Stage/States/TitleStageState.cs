using UnityEngine;
using UnityEngine.UIElements;
using Managers;
using State;

[CreateAssetMenu(fileName = "TitleStageState", menuName = "State/Stage/Title")]
public class TitleStageState : StateData<StageContoller>
{
    public override bool IsPlayable(StageContoller controller)
    {
        return true;
    }

    public override void OnEnter(StageContoller controller)
    {
        
    }

    public override void OnProcessing(StageContoller controller)
    {
        
    }

    public override void OnExit(StageContoller controller)
    {
        
    }
}
