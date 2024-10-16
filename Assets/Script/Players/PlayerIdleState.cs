using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// �÷��̾ ��� ������ ���� ��ü���� ������ �����Ѵ�. 
public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName) 
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

        if (input.MoveDirection.x != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }
}
