using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float jumpForce;

    PlayerStateMachine stateMachine;

    private Player player;

    #region 플레이어 제어 변수

    public bool IsJumping { get; set; }
    public bool IsAttacking { get; private set; } = false;

    #endregion
    public Rigidbody2D Rb { get { return rb; } set { rb = value; } }

    #region 인풋액션
    [Header("플레이어 액션")]
    [Tooltip("플레이어의 인풋액션")]
    public InputActionAsset actionsAsset;

    [Tooltip("인풋 액션맵")]
    private InputActionMap playerActionMap;

    [Tooltip("플레이어의 Fall 액션")]
    private InputAction fallAction;

    [Tooltip("플립의 전환을 불가능 하도록 만드는 변수")]
    public bool canFlip { get; set; } = true;

    #region Spec
    [Header("플레이어의 Spec")]
    [Tooltip("아래 방향 키 누를 시 내려가는 움직임")]
    public float downForce = 5f;

    [Tooltip("아래 방향키 누르고 있는지 확인")]
    private bool isFallingPressed = false;
    #endregion
    public bool IsFallingPressed { get { return isFallingPressed; } }

    #endregion
    public Vector2 MoveDirection { get { return moveDirection; } set { moveDirection = value; } }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        jumpForce = 10f;
        player = GetComponent<Player>();
        playerActionMap = actionsAsset.FindActionMap("Player", true);
        if (playerActionMap != null)
        {
            fallAction = playerActionMap.FindAction("Fall", true);
            Debug.Log(fallAction.name);
        }
    }

    private void Start()
    {
        
    }

    // 이벤트 등록으로 키를 누르고 있는 상황인지 아닌지를 체크한다. 
    private void OnEnable()
    {
        // 직접 컴포넌트로 불러오는 액션들은 Enable로 활성화 시켜줘야한다. 
        fallAction.Enable();
        fallAction.started += OnFallStarted;
        fallAction.canceled += OnFallCanceled;
    }

    private void OnDisable()
    {
        fallAction.started -= OnFallStarted;
        fallAction.canceled -= OnFallCanceled;
        fallAction.Disable();
    }


    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if (input != null)
        {
            moveDirection = new Vector2(input.x, rb.velocity.y);
        }
        else // 인풋이 없는 상황이라면 
        {
            moveDirection = new Vector2(0, rb.velocity.y);
        }
    }
    private void OnJump()
    {
        // IsJumping을 상태들에서 관리하여 False 일 때만 점프 가능하도록 
        if (IsJumping == false)
        {
            Debug.Log("OnJump 실행");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            IsJumping = true;
        }
    }
    private void Update()
    {
        Debug.Log($"점프 플래그 ->{IsJumping}");
    }

    private void FixedUpdate()
    {
        UpdatePlayer();
    }

    private void UpdatePlayer()
    {
        // 플립이 변경되어서는 안되는 상태들. 
        // 1. 대시상태 2. 사망상태 3. 공격 중 
        
        if(canFlip)
        {
            if (moveDirection.x < 0)
            {
                player.Sprite.flipX = true;
            }
            else if (moveDirection.x > 0)
            {
                player.Sprite.flipX = false;
            }
        }
        
        
    }

    public Vector2 GetDir()
    {
        return moveDirection;
    }

    public void PlayerMove(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
    }

    private void OnFallStarted(InputAction.CallbackContext context)
    {
        isFallingPressed = true;
    }

    private void OnFallCanceled(InputAction.CallbackContext context)
    {
        isFallingPressed = false;
    }

    




}
