using System;
using State;
using UnityEngine;

public class PlayerController : Controller
{
    public PlayerInput Input;
    public Rigidbody2D Rigid2D;

    [field:SerializeField] public Context<PlayerController, StateData<PlayerController>> Context { get; private set; }

    private void Start()
    {
        Context = new Context<PlayerController, StateData<PlayerController>>();
        Context.Init(this);

        Context.SearchNextState(this);
    }

    private void Update()
    {
        Context.CurrentState?.OnProcessing(this);
    }

    public void UpdateNextState()
    {
        Context.SearchNextState(this);
    }
}
