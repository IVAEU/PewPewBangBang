using State;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerIdleState", menuName = "State/Player/Idle")]
public class SP_Idle : StateData<PlayerController>
{
    public override bool IsPlayable(PlayerController controller)
    {
        return controller.Input.GetMoveVector() == Vector2.zero;
    }
    
    public override void OnEnter(PlayerController controller)
    {
        
    }

    public override void OnProcessing(PlayerController controller)
    {
        if (controller.Input.GetMoveVector() != Vector2.zero)
        {
            controller.UpdateNextState();
        }
    }

    public override void OnExit(PlayerController controller)
    {
        
    }
}