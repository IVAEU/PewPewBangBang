using UnityEngine;
using State;

public class SPB_Idle : IState<PlayerController>
{
    public void OnEnter(PlayerController controller)
    {
        
    }

    public void OnProcessing(PlayerController controller)
    {
        if (controller.Input.IsPrimaryKeyDown())
        {
            controller.Context.ChangeState(SubStateType.Behavior, StateType.Attack);
        }
    }

    public void OnExit(PlayerController controller)
    {
        
    }
}
