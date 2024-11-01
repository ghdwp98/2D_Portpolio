using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName)
        : base(input, player, stateMachine, animBoolName)
    {

    }



    // 떨어지고 있는 모든 상황 

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
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public override void Update()
    {
        base.Update();

        // 하강 중 좌우 이동 가능
        player.moveState.PlayerMove();

        // 착지 및 velocity.y 가 음수가 아니면 Idle로 전환
        if(player.IsGrounded && (input.Rb.velocity.y >= -0.01))
        {
            stateMachine.ChangeState(player.idleState);
            Debug.Log("Fall -> Idle");
        }

        //점프 중 아래 키 누르고 있을 시 더 빠르게 내려옴 
        if (input.IsFallingPressed)
        {
            input.Rb.AddForce(Vector2.down * input.downForce, ForceMode2D.Force);
            Debug.Log("아래 키");
        }

        if (input.actionsAsset["Dash"].triggered)
        {      
            stateMachine.ChangeState(player.dashState);
        }


    }
}
