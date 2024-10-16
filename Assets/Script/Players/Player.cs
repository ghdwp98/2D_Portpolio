using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� Ŭ���� 
public class Player : MonoBehaviour
{
    public PlayerInput PlayerInput {get; private set; }
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerGroundedState groundedState { get; private set; }

    #region ����ó�� 
    [SerializeField] private bool isGrounded = false;
    public bool IsGrounded { get { return isGrounded; } }

    [SerializeField]
    private int groundLayer = 1 << 8;
    #endregion

    #region Components
    [Header("������Ʈ")]
    private Animator anim;
    private SpriteRenderer sprite;

    [Tooltip("�ٴ� üũ �Ÿ�")]
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
        stateMachine.currentState.Update(); // ���� ���¸ӽ��� ������Ʈ ���� 
        // Player�� GroundCheck�� �ֻ�ܿ��� �ǽ�. 

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
