using System.Collections;
using System.Collections.Generic;
using Unity.XR.GoogleVr;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(PlayerInput input, Player player, PlayerStateMachine stateMachine, string animBoolName) 
        : base(input, player, stateMachine, animBoolName)
    {

    }

    [Tooltip("플레이어의 대시 시간")]
    [ SerializeField] private float dashTimer;
    [Tooltip("플레이어의 대시 속도")]
    [SerializeField] public float dashSpeed = 15f;

    [Tooltip("플레이어 스프라이트의 Flip.x 값")]
    private bool isFacingRight;

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Dash State 진입");

        input.canFlip = false; // 대시 중에는 플립 변경이 불가능.       
        dashTimer = 1f;

        // 대시 중 방향을 고정시키기 때문에 Enter 에서 한 번만 방향 체크
        isFacingRight = !player.Sprite.flipX;
        Vector2 dashDir = isFacingRight ? Vector2.right : Vector2.left;
        if (player.IsGrounded)
        {
            input.Rb.velocity = new Vector2(dashDir.x * dashSpeed, input.Rb.velocity.y);
        }
        // 공중 대시 중 중력 감소 (Grounded 상태가 아니면 )
        else
        {
            input.Rb.gravityScale = 0f;
            input.Rb.velocity = new Vector2(dashDir.x * dashSpeed, 0f);
        }

    }
    public override void Exit()
    {
        base.Exit();
        input.Rb.gravityScale = 1f; // 중력복귀 
        input.Rb.velocity = Vector2.zero;
        input.canFlip = true; 
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
        dashTimer -= Time.deltaTime;

        // 플레이어가 바라보고 있는 방향으로 대시 힘을 가한다. 
        if(dashTimer<=0)
        {          
            stateMachine.ChangeState(player.idleState);          
        }

    }
}
