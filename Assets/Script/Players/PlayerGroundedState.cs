using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 땅 위에 있는 상황들의 부모 클래스. 
public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName)
        : base(input, player, stateMachine, animBoolName)
    {

    }

    // 땅 체크를 스크립트로 따로 둘지 그냥 그라운드 체크로만 체크할지는 생각해보기. 

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public override void Update()
    {
        base.Update();
        /*if(input.IsJumping ==true && player.IsGrounded == false)
        {
            stateMachine.ChangeState(player.jumpState); 
        }
*/
        if (input.actionsAsset["Dash"].triggered)
        {
            stateMachine.ChangeState(player.dashState);
        }

        if (input.actionsAsset["Zattack"].triggered && player.CanAttack)
        {
            stateMachine.ChangeState(player.zattackState);

        }

        if (input.IsJumping == true && player.IsGrounded == false)
        {
            stateMachine.ChangeState(player.jumpState);
        }

    }
}
