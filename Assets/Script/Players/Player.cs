using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 클래스 
public class Player : MonoBehaviour
{
    public PlayerInput PlayerInput {get; private set; }
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerGroundedState groundedState { get; private set; }

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

    public SpriteRenderer Sprite { get { return sprite; } }
    public Animator Anim { get { return anim; } }

    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        PlayerInput = GetComponent<PlayerInput>();        
        idleState = new PlayerIdleState(PlayerInput , this , stateMachine , "Idle");
        moveState = new PlayerMoveState(PlayerInput, this, stateMachine, "Move");
        groundCheckDistance = 1f;
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

        isGrounded = GroundCheck();
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

}
