using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

// 플레이어 클래스 
public class Player : MonoBehaviour
{
    public PlayerInput Input {get; private set; }
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerGroundedState groundedState { get; private set; }

    //약공 z 키 
    public PlayerZattackState zattackState { get; private set; }

    // 추락상황 
    public PlayerFallState fallState { get; private set; }  

    public PlayerDashState dashState { get; private set; }

    #region 조건처리 
    [SerializeField] private bool isGrounded = false;
    public bool IsGrounded { get { return isGrounded; } }

    [SerializeField]
    private int groundLayer = 1 << 8;
    #endregion

    #region Components
    [Header("컴포넌트")]
    private Animator anim;
    private SpriteRenderer sprite;

    [Tooltip("바닥 체크 거리")]
    [SerializeField] private float groundCheckDistance;

    [Tooltip("추락 상태 체크 -> Rb.Y와 Flaot 값 이용 -> Parameter name : Fall")]
    [SerializeField] private float fallingFloat;

    [Tooltip("플레이어의 last공격 이후 쿨타임")]
    private float attackCooldown = 1.3f;
    private float attackCooldownTimer = 0f;

    public bool CanAttack => attackCooldownTimer <= 0f; // 공격 가능 여부 판단

    public float FallingFloat { get { return fallingFloat;} set { fallingFloat = value; } }
    
    public SpriteRenderer Sprite { get { return sprite; } set { sprite = value; } }
    public Animator Anim { get { return anim; } }

    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        Input = GetComponent<PlayerInput>();        
        idleState = new PlayerIdleState(Input , this , stateMachine , "Idle");
        moveState = new PlayerMoveState(Input, this, stateMachine, "Move");
        jumpState = new PlayerJumpState(Input, this, stateMachine, "Jump");
        zattackState = new PlayerZattackState(Input, this, stateMachine,"Zattack1");
        fallState = new PlayerFallState(Input, this, stateMachine, "Fall");
        dashState = new PlayerDashState(Input, this, stateMachine, "Dash");

        groundCheckDistance = 1.05f;
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        stateMachine.InitialIze(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update(); // 현재 상태머신의 업데이트 진행 
        // Player의 GroundCheck는 최상단에서 실시. 

        // 공격 쿨타임 감소 처리
        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
            Debug.Log(CanAttack + "캔 어택 상태 ");
            Debug.Log(attackCooldownTimer + "쿨다운 시간");
        }

        
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.FixedUpdate();

        GroundCheck();

        // Fall 상태 체크 fallingFalot 값 이용 -> 0 이하면 Fall 상태진입

        if(!isGrounded && Input.Rb.velocity.y < 0f) // 땅이 아니고 추락중인 상황. 
        {
            stateMachine.ChangeState(fallState);          
        }
    }

    private void LateUpdate()
    {
        stateMachine.currentState.LateUpdate();
    }

    private bool GroundCheck()
    {      
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if(hit.collider != null )
        {
            isGrounded = true;
            return isGrounded; 
        }
        else
        {
            isGrounded = false;
            return isGrounded;
        }
    }

    // 호출 받을 함수
    public void AnimationTrigger()
    {
        stateMachine.currentState.AnimationFinishTrigger();
    }

    // 외부에서 불러서 공격 쿨타운을 시작할 함수. 
    public void StartAttackCooldown()
    {
        attackCooldownTimer = attackCooldown;
    }

}
