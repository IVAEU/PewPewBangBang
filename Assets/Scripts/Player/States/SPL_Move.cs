using State;
using UnityEngine;

public class SPL_Move : IState<PlayerController>
{
    public void OnEnter(PlayerController controller)
    {
        
    }

    public void OnProcessing(PlayerController controller)
    {
        controller.Rigid2D.linearVelocity = controller.Input.GetMoveVector() * controller.Data.Speed;
        
        if (controller.Input.GetMoveVector() == Vector2.zero)
        {
            controller.LocomotionStateMachine.ChangeState(PlayerController.LocomotionState.Idle);
        }
    }

    public void OnExit(PlayerController controller)
    {
        
    }
}
