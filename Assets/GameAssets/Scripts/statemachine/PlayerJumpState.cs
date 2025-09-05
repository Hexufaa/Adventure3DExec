using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerJumpState : PlayerState
{
    private float jumpHeight = 2f;
    private float jumpDuration = 0.5f;
    private float jumpTimer = 0f;
    private Vector3 startPosition;

    public PlayerJumpState(PlayerStateMachine stateMachine, Transform playerTransform)
        : base(stateMachine, playerTransform) { }

    public override void Enter()
    {
        jumpTimer = 0f;
        startPosition = playerTransform.position;
    }

    public override void Update()
    {
        jumpTimer += Time.deltaTime;
        float progress = jumpTimer / jumpDuration;

        if (progress >= 1f)
        {
            // Voltar para Idle após o pulo
            stateMachine.ChangeState(new PlayerIdleState(stateMachine, playerTransform));
            return;
        }

        // Curva de pulo simples (parábola)
        float height = 4f * jumpHeight * progress * (1 - progress);
        Vector3 newPosition = startPosition + Vector3.up * height;
        playerTransform.position = new Vector3(
            playerTransform.position.x,
            newPosition.y,
            playerTransform.position.z
        );
    }
}

