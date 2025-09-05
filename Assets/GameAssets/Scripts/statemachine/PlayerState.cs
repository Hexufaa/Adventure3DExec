using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Transform playerTransform;

    public PlayerState(PlayerStateMachine stateMachine, Transform playerTransform)
    {
        this.stateMachine = stateMachine;
        this.playerTransform = playerTransform;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}

