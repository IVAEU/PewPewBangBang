using System;
using System.Linq;
using State;
using UnityEngine;

public class PlayerController : MonoBehaviour, IController
{
    public ShipData Data;
    public PlayerInput Input;
    public Rigidbody2D Rigid2D;

    [field: SerializeField]
    public Context<PlayerController> Context { get; private set; }

    private void Start()
    {
        Input = GetComponent<PlayerInput>();
        Rigid2D = GetComponent<Rigidbody2D>();
        Context = new Context<PlayerController>();
        Context.Init(this);
        Context.AddState(SubStateType.Locomotion, StateType.Idle, new SPL_Idle());
        Context.AddState(SubStateType.Locomotion, StateType.Move, new SPL_Move());
        Context.AddState(SubStateType.Behavior, StateType.Idle, new SPB_Idle());
        Context.AddState(SubStateType.Behavior, StateType.Attack, new SPB_Shoot());

        Context.ChangeState(SubStateType.Locomotion, StateType.Idle);
        Context.ChangeState(SubStateType.Behavior, StateType.Idle);
    }

    private void Update()
    {
        foreach (var state in Context.CurrentState.ToList())
        {
            state.Value.OnProcessing(this);
        }
    }
}
