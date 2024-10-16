using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float jumpForce;

    private Player player;

    public bool IsJumping { get; private set; } = false;
    public bool IsAttacking { get; private set; } = false;


    public Vector2 MoveDirection { get { return moveDirection;  }set { moveDirection = value; } }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        jumpForce = 10f;
    }

    private void Start()
    {
        player = GetComponent<Player>();
    }


    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if(input!=null)
        {
            moveDirection = new Vector2 (input.x, input.y);
        }
        else
        {
            moveDirection = Vector2.zero;
        }
    }
    private void OnJump()
    {
        rb.AddForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
    }

    private void Update()
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

    public Vector2 GetDir()
    {
        return moveDirection;
    }

    public void PlayerMove(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
    }

}
