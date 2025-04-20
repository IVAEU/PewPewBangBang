using State;
using UnityEngine;

public class SEA_Idle : IState<EnemyController>
{
    private float targetTime = 3f;
    private float currentTime = 0f;
    
    public void OnEnter(EnemyController controller)
    {
        Debug.Log("이제 쉬기");
        currentTime = 0;
    }

    public void OnProcessing(EnemyController controller)
    {
        currentTime += Time.deltaTime;
        if (currentTime >= targetTime)
        {
            controller.AttackStateMachine.ChangeState(EnemyController.AttackState.Attack);
        }
    }

    public void OnExit(EnemyController controller)
    {
        
    }
}
