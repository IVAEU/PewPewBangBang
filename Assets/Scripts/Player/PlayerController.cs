using System.Linq;
using Managers;
using State;
using UnityEngine;

public class PlayerController : Controller, IPoolObject
{
    public enum LocomotionState
    {
        Idle,
        Move
    }
    
    public enum AttackState
    {
        Idle,
        Attack
    }
    
    public ShipData Data { get; private set; }
    public HealthSystem Health { get; private set; }
    public PlayerInput Input { get; private set; }
    public Rigidbody2D Rigid2D { get; private set; }
    public SpriteRenderer Renderer { get; private set; }

    public StateMachine<LocomotionState, PlayerController> LocomotionStateMachine { get; private set; }
    public StateMachine<AttackState, PlayerController> AttackStateMachine { get; private set; }

    public void ConstructObject()
    {
        Data = DataManager.Instance.GetSelectedPlayerShipData();
        Health = gameObject.AddComponent<HealthSystem>();
        Health.Initialize(Data.HealthPoint);
        Input = gameObject.AddComponent<PlayerInput>();
        Rigid2D = gameObject.AddComponent<Rigidbody2D>();
        Rigid2D.gravityScale = 0;
        Renderer = gameObject.AddComponent<SpriteRenderer>();
        Renderer.sprite = Data.ShipSprite;
    }

    public void DeconstructObject()
    {
        Destroy(Health);
        Destroy(Input);
        Destroy(Rigid2D);
        Destroy(Renderer);
    }
    
    private void Start()
    {
        LocomotionStateMachine = new ();
        LocomotionStateMachine.Init(this);
        LocomotionStateMachine.AddState(LocomotionState.Idle, new SPL_Idle());
        LocomotionStateMachine.AddState(LocomotionState.Move, new SPL_Move());
        
        AttackStateMachine = new ();
        AttackStateMachine.Init(this);
        AttackStateMachine.AddState(AttackState.Idle, new SPA_Idle());
        AttackStateMachine.AddState(AttackState.Attack, new SPA_Shoot());
        
        LocomotionStateMachine.ChangeState(LocomotionState.Idle);
        AttackStateMachine.ChangeState(AttackState.Idle);
    }

    private void Update()
    {
        LocomotionStateMachine.CurrentState.OnProcessing(this);
        AttackStateMachine.CurrentState.OnProcessing(this);
    }

    private void OnDeath()
    {
        EventManager.Instance.ProcessEvent(GameEvent.Player_Death);
        PoolManager.Instance.ReturnObject(this);
    }
}
