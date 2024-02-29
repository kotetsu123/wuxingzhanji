using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Wizard_Controler : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    //private Vector2 lookDirection = new Vector2(1, 0);//初始朝向
    private Vector2 lookDirection = Vector2.right;
    private bool isLookUp = false;
    private bool isRunning = false;
    private bool isJumping = false;
    private bool canJump;
    private bool isGrounded;//是否接触地面

    
    public float moveSpeed = 3f;
    public float jumpForce=10f;//跳跃力度
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;



    public static Wizard_Controler instance;
    private static Wizard_Controler Instance { get => instance; set => instance = value; }
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
    }

   
    void Update()
    {
        Movement();
        /*isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        if (Input.GetKeyDown(KeyCode.Space) &&isGrounded)
        {
            canJump = true;
        }*/
    }
    private void FixedUpdate()
    {
       /* if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false;
            isJumping = true;
            animator.SetBool("isJump", isJumping);
        }
        else
        {
            isJumping = false;
            animator.SetBool("isJump", isJumping);
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y>0&&Input.GetKey(KeyCode.Space))
        {
            rb.velocity+=Vector2.up*Physics2D.gravity.y*(lowJumpMultiplier - 1) * Time.deltaTime;
        }*/
    }
    private void Movement()
    {
        Vector2 position = transform.position;
        //float v = Input.GetAxisRaw("Vertical");//垂直
        //float v = Input.GetKeyDown(KeyCode.W) ? 1f:0f ;
        float v = isLookUp ? 1f : 0f;
        //float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");//水平
        Vector2 move = new Vector2(h, 0);
        // Vector2 move = new Vector2(h, v).normalized;

        if (!Mathf.Approximately(move.x, 0) && Mathf.Approximately(v, 0))//当玩家输入轴向不为0
        {
            lookDirection.Set(move.x, v);
            lookDirection.Normalize();//归一化，返回大小为1的向量，不需要上面实际的大小，只需要它的向量。
            isRunning = true;
            //animator.SetBool("isRun", true);

        }
        else
        {
            isRunning = false;
            //animator.SetBool("isRun", false);
        }
       /* if (move.magnitude > 0 && Mathf.Approximately(v, 0))
        {
            lookDirection = move;
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }*/
        animator.SetBool("isRun", isRunning);
        //animator.SetFloat("lookDirectionY", lookDirection.y);
        animator.SetFloat("lookDirection", lookDirection.x);
        position = position + moveSpeed * move * Time.fixedDeltaTime;
        rb.MovePosition(position);
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            isLookUp = true;
            animator.SetBool("isLookUp", isLookUp);
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            isLookUp = false;
            animator.SetBool("isLookUp", isLookUp);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        animator.SetBool("isJump", isJumping);
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isJumping = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
