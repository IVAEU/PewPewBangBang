using UnityEngine;
using State;

public class SEA_Shoot : IState<EnemyController>
{
    private float targetTime = 3f;
    private float currentTime = 0f;
    
    public void OnEnter(EnemyController controller)
    {
        Debug.Log("발사");
        currentTime = 0;
    }

    public void OnProcessing(EnemyController controller)
    {
        currentTime += Time.deltaTime;
        if (currentTime >= targetTime)
        {
            controller.AttackStateMachine.ChangeState(EnemyController.AttackState.Idle);
        }
    }

    public void OnExit(EnemyController controller)
    {
        
    }
}
