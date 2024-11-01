using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZattackState : PlayerState
{
    public PlayerZattackState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName) : base(input, player, stateMachine, animBoolName)
    {

    }


    
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Zattack 진입");
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

        // 공격 애니메이션의 마지막 프레임이 실행 -> 연속공격 x -> Idle 상태로 전환. 
        if(triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }
}
