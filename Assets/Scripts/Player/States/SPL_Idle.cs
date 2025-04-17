using State;
using UnityEngine;

public class SPL_Idle : IState<PlayerController>
{
    public void OnEnter(PlayerController controller)
    {
        
    }

    public void OnProcessing(PlayerController controller)
    {
        if (controller.Input.GetMoveVector() != Vector2.zero)
        {
            controller.Context.ChangeState(SubStateType.Locomotion, StateType.Move);
        }
    }

    public void OnExit(PlayerController controller)
    {
        
    }
}