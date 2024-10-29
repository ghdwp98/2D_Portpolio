using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName) : base(input, player, stateMachine, animBoolName)
    {

    }

    [Tooltip("점프 중 하강 시작 타이밍 체크 ")]
    public bool isFallingStart = false;

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
        isFallingStart = false;
    }

    public override void LateUpdate()
    {
        base.LateUpdate();

    }

    public override void Update()
    {
        base.Update();
        if (player.IsGrounded)
        {
            player.Anim.SetBool("IsFalling", false);
            stateMachine.ChangeState(player.idleState);
            Debug.Log("Jump -> Idle");
        }

        // 점프 중 이동가능 
        player.moveState.PlayerMove();

        // 점프 하강 중 Fall 애니메이션 재생
        if (input.Rb.velocity.y < -0.1f && isFallingStart == false)
        {
            player.Anim.SetBool("IsFalling", true);
        }
        //점프 중 아래 키 누르고 있을 시 더 빠르게 내려옴 

        if(input.IsFallingPressed)
        {
            //ForceMode2D.Force -> 연속적인힘. 
            input.Rb.AddForce(Vector2.down * input.downForce, ForceMode2D.Force);
            Debug.Log("아래 키");
        }


    }

}
