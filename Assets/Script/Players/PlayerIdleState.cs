using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// 플레이어가 대기 상태일 때의 구체적인 동작을 정의한다. 
public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName) 
        : base(input, player, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Idle State 진입");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (input.MoveDirection.x != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }

        if (input.IsJumping == true && player.IsGrounded == false)
        {
            stateMachine.ChangeState(player.jumpState);
        }

        //Trigger를 통해 발생한 순간에만 작동가능. 
        // 이 방식대로 각 상태에서 인풋액션 확인가능
        // IsPressed로 눌려있는 상태 확인 가능

        if (input.actionsAsset["Dash"].triggered && (stateMachine.currentState != player.dashState))
        {
            Debug.Log("Player에서 Dash 관리");
            stateMachine.ChangeState(player.dashState);
        }


    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }
}
