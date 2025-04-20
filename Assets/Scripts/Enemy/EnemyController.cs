using State;
using UnityEngine;

public class EnemyController : Controller, IPoolObject
{
    public enum LocomotionState
    {
        Move
    }
    
    public enum AttackState
    {
        Idle,
        Attack
    }

    public Rigidbody2D Rigid2D { get; private set; }
    
    public StateMachine<LocomotionState, EnemyController> LocomotionStateMachine { get; private set; }
    public StateMachine<AttackState, EnemyController> AttackStateMachine { get; private set; }
    
    public void ConstructObject()
    {
        Rigid2D = gameObject.AddComponent<Rigidbody2D>();
    }
    
    public void DeconstructObject()
    {
        Destroy(Rigid2D);
    }
    
    private void Start()
    {
        LocomotionStateMachine = new ();
        LocomotionStateMachine.Init(this);
        LocomotionStateMachine.AddState(LocomotionState.Move, new SEL_Move());
        
        AttackStateMachine = new ();
        AttackStateMachine.Init(this);
        AttackStateMachine.AddState(AttackState.Idle, new SEA_Idle());
        AttackStateMachine.AddState(AttackState.Attack, new SEA_Shoot());
        
        LocomotionStateMachine.ChangeState(LocomotionState.Move);
        AttackStateMachine.ChangeState(AttackState.Idle);
    }
    
    private void Update()
    {
        LocomotionStateMachine.CurrentState.OnProcessing(this);
        AttackStateMachine.CurrentState.OnProcessing(this);
    }
}
