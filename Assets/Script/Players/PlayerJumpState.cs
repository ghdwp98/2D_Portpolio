using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpState : PlayerState
{
    // 점프 키를 누르고 들어오는 점프상황. 
    public PlayerJumpState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName) : base(input, player, stateMachine, animBoolName)
    {

    }


    public override void Enter()
    {
        base.Enter();
        Debug.Log("JumpState 진입");
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
       
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
        // 점프 중 이동가능 
        player.moveState.PlayerMove();

        // Velociy.y <0 으로 변하면 추락하는 상황이로 전이필요. 

        if(!player.IsGrounded && (input.Rb.velocity.y <0))
        {
            stateMachine.ChangeState(player.fallState);
            Debug.Log("Jump -> Fall");
        }

        //점프 중 아래 키 누르고 있을 시 더 빠르게 내려옴 
        if (input.IsFallingPressed)
        {
            input.Rb.AddForce(Vector2.down * input.downForce, ForceMode2D.Force);
            Debug.Log("아래 키");
        }

        if (input.actionsAsset["Dash"].triggered && (stateMachine.currentState != player.dashState))
        {
            
            stateMachine.ChangeState(player.dashState);
        }

    }

}
