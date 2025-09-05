using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    private float speed = 5f;

    public PlayerMoveState(PlayerStateMachine stateMachine, Transform playerTransform)
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

        if (horizontal == 0 && vertical == 0)
        {
            stateMachine.ChangeState(new PlayerIdleState(stateMachine, playerTransform));
            return;
        }

        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;
        playerTransform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}

