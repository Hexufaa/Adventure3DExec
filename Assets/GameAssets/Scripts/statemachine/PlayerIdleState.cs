using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerStateMachine stateMachine, Transform playerTransform)
        : base(stateMachine, playerTransform) { }

    public override void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(new PlayerJumpState(stateMachine, playerTransform));
            return;
        }

        if (horizontal != 0 || vertical != 0)
        {
            stateMachine.ChangeState(new PlayerMoveState(stateMachine, playerTransform));
        }
    }
}

