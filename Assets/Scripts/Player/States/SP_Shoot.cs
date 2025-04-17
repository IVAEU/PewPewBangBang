using State;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerShootState", menuName = "State/Player/Shoot")]
public class SP_Shoot : StateData<PlayerController>
{
    [SerializeField] private GameObject projectile;
    
    public override bool IsPlayable(PlayerController controller)
    {
        return controller.Input.IsPrimaryAttackDown();
    }

    public override void OnEnter(PlayerController controller)
    {
        Instantiate(projectile, controller.transform);
        controller.UpdateNextState();
    }

    public override void OnProcessing(PlayerController controller)
    {
        if (controller.Input.IsPrimaryAttackUp())
        {
            //controller.SearchNextState();
        }
    }

    public override void OnExit(PlayerController controller)
    {
        
    }
}
