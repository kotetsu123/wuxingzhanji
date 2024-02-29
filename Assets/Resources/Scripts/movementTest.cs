using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class movementTest : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private bool isRunning;
    private bool isLookUp;
    private bool moveJump;
    private bool isJumping;
    private bool faceRight = true;
    private float moveX;


    [Range(1,10)]
    public float Speed = 5f;
    public float jumpSpeed = 5f;
    public bool isGrounded; //在地面上
    public Transform groundCheck;//检测点
    public LayerMask ground;//图层


    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
    }
    private void Move()
    {
        
        moveX = Input.GetAxisRaw("Horizontal");
        moveJump = Input.GetButtonDown("Jump");
       
        rb.velocity = new Vector2(moveX*Speed, rb.velocity.y);
       
        if ((faceRight && moveX < 0 || !faceRight && moveX > 0))//1面向右但是再往左移动，2面向做但是再往右移动
        {
            Flip();
        }
        if (Input.GetKey(KeyCode.W))
        {
            isLookUp = true;
        }
        else
        {
            isLookUp = false;
        }
        if (moveJump&&isGrounded)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            isJumping = true;
        }
        if (!isGrounded)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
       
        isRunning = Mathf.Abs(moveX) > 0;
        animator.SetBool("isJump", isJumping);
        animator.SetBool("isRun", isRunning);
        animator.SetBool("isLookUp", isLookUp);
        
    }
    private void Flip()
    {
        faceRight =! faceRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
    
}
