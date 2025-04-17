using State;
using UnityEngine;

public class SPB_Shoot : IState<PlayerController>
{
    public void OnEnter(PlayerController controller)
    {
        Debug.Log("Shoot");
        controller.Context.ChangeState(SubStateType.Behavior, StateType.Idle);
    }

    public void OnProcessing(PlayerController controller)
    {
    }

    public void OnExit(PlayerController controller)
    {
        
    }
}
