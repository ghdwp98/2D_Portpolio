using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ �̵� ���϶��� ��ü���� ������ �����Ѵ�. 
public class PlayerMoveState : PlayerState
{

    public PlayerMoveState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName)
        : base(input, player, stateMachine, animBoolName)
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

    public override void Update()
    {
        base.Update();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
        PlayerMove();

        if(input.MoveDirection.x==0)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }

    public void PlayerMove()
    {
        Vector2 moveDir = input.GetDir();
        input.PlayerMove(moveDir);
    }


}
