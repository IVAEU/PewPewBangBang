using State;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMoveState", menuName = "State/Player/Move")]
public class SP_Move : StateData<PlayerController>
{
    public override bool IsPlayable(PlayerController controller)
    {
        return controller.Input.GetMoveVector() != Vector2.zero;
    }

    public override void OnEnter(PlayerController controller)
    {
        
    }

    public override void OnProcessing(PlayerController controller)
    {
        controller.Rigid2D.linearVelocity = controller.Input.GetMoveVector() * 5;
        
        if (controller.Input.GetMoveVector() == Vector2.zero)
        {
            controller.UpdateNextState();
        }
    }

    public override void OnExit(PlayerController controller)
    {
        
    }
}
