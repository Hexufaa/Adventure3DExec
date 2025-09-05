using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStateMachine : MonoBehaviour
{
    private PlayerState currentState;

    void Start()
    {
        ChangeState(new PlayerIdleState(this, transform));
    }

    void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(PlayerState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
