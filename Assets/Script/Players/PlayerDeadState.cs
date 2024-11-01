using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName) : base(input, player, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        // 부활을 원하는지에 대한 문구를 출력한다. 
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

        // 부활을 클릭하면 체크포인트 + 부활석 1개 차감 + 부활 상태로 전이 



    }
}
