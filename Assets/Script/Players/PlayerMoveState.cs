using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 이동 중일때의 구체적인 동작을 정희한다. 
public class PlayerMoveState : PlayerGroundedState
{

    public PlayerMoveState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName)
        : base(input, player, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Move State 진입");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (input.MoveDirection.x == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }


    public override void FixedUpdate()
    {
        base.FixedUpdate(); 
    }

    public override void LateUpdate()
    {
        base.LateUpdate();

    }

}
