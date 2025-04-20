using UnityEngine;
using State;

public class SEL_Move : IState<EnemyController>
{
    public void OnEnter(EnemyController controller)
    {
        
    }

    public void OnProcessing(EnemyController controller)
    {
        //Debug.Log("아래로 이동");
    }

    public void OnExit(EnemyController controller)
    {
        
    }
}
