using State;
using Managers;
using UnityEngine;

public class SPA_Shoot : IState<PlayerController>
{
    public void OnEnter(PlayerController controller)
    {
        Debug.Log("Shoot");
        EventManager.Instance.ProcessEvent(GameEvent.Player_Shoot);
        controller.AttackStateMachine.ChangeState(PlayerController.AttackState.Idle);
    }

    public void OnProcessing(PlayerController controller)
    {
    }

    public void OnExit(PlayerController controller)
    {
        
    }
}
