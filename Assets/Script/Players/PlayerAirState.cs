using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName) : base(input, player, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        // 하강 중 좌우 이동 가능
        player.moveState.PlayerMove();

        //점프 중 아래 키 누르고 있을 시 더 빠르게 내려옴 
        if (input.IsFallingPressed)
        {
            input.Rb.AddForce(Vector2.down * input.downForce * 10, ForceMode2D.Force);
            Debug.Log("아래 키");
        }

        // Fall 상태 체크 -> 0 이하면 Fall 상태진입
        if (!player.IsGrounded && input.Rb.velocity.y < 0f && (stateMachine.currentState != player.fallState)) // 땅이 아니고 추락중인 상황. 
        {
            stateMachine.ChangeState(player.fallState);
        }

        // 착지 및 velocity.y 가 음수가 아니면 Idle로 전환
        if (player.IsGrounded && (input.Rb.velocity.y >= -0.01))
        {
            input.IsJumping = false; // 점프 플래그 초기화로 다시 점프 가능하도록
            stateMachine.ChangeState(player.idleState);
        }

    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public override void Update()
    {
        base.Update();
        if (input.actionsAsset["Dash"].triggered)
        {
            stateMachine.ChangeState(player.dashState);
        }

    }
}
