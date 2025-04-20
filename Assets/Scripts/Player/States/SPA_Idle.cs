using UnityEngine;
using State;

public class SPA_Idle : IState<PlayerController>
{
    public void OnEnter(PlayerController controller)
    {
        
    }

    public void OnProcessing(PlayerController controller)
    {
        if (controller.Input.IsPrimaryKeyDown())
        {
            controller.AttackStateMachine.ChangeState(PlayerController.AttackState.Attack);
        }
    }

    public void OnExit(PlayerController controller)
    {
        
    }
}
