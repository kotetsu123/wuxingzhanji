using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class movementTest : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public ParticleSystem playerWalkDust;

    private bool isRunning;
    private bool isLookUp;
    private bool moveJump;
    private bool isJumping;//���ݶ���������
    private bool isJump;//���ݲ�����
    
    private bool jumpHold;
    private bool faceRight = true;
    private float moveX;


    [Range(1, 10)]
    public float Speed = 5f;
    [Range(1,10)]
    public float jumpSpeed = 5f;
    public bool isGrounded; //�ڵ�����
    public Transform groundCheck;//����
    public LayerMask ground;//ͼ��
    

    public float fallMultiplier=3.0f;//�½����ٶ�
    public float jumpMultiplier = 2.0f;//�����ӳ�
    public int jumpTime = 1;//��Ծ����

    public bool canDoubleJump ;//�������ж�
    public bool singleJumpOnly = true;//������Ծ�ж�



    //����
    private static movementTest instance;
    public static movementTest Instance { get => instance; set => instance = value; }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        
    }
    private void Move()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        


        rb.velocity = new Vector2(moveX*Speed, rb.velocity.y);
       
        if ((faceRight && moveX < 0 || !faceRight && moveX > 0))//1�����ҵ����������ƶ���2�����������������ƶ�
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
       
       
        isRunning = Mathf.Abs(moveX) > 0;
       
        animator.SetBool("isRun", isRunning);
        animator.SetBool("isLookUp", isLookUp);
        
    }
    private void Flip()
    {
        faceRight =! faceRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
        PlayerWalkDust();
    }
    private void Jump()
    {
        moveJump = Input.GetButtonDown("Jump");
        jumpHold = Input.GetButton("Jump");
        /*if (moveJump && jumpTime > 0)
        {
            isJump = true;
        }
        if (isJump)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            jumpTime--;
            isJump = false;

        }

        if (isGrounded)
        {
            jumpTime = 1;
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }*/
        if (moveJump && isGrounded && singleJumpOnly)
        {
            isJump = true;
        }
        if (isJump)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isJump = false;
            PlayerWalkDust();
        }
        if (moveJump && jumpTime > 0 && canDoubleJump)
        {
            isJump = true;
        }
        if (isJump)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            jumpTime--;
            isJump = false;
            PlayerWalkDust();
        }
        if (isGrounded)
        {
            jumpTime = 1;
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }
        if (rb.velocity.y < 0)
        {
            // rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier-1)*Time.fixedDeltaTime;
            rb.gravityScale = fallMultiplier;
        }
        else if (rb.velocity.y > 0 && !jumpHold)
        {
            //rb.velocity += Vector2.up * Physics2D.gravity.y * (jumpMultiplier - 1) * Time.fixedDeltaTime;
            rb.gravityScale = jumpMultiplier;
        }
        else
        {
            rb.gravityScale = 1;
        }
        
        animator.SetBool("isJump", isJumping);
    }
    private void PlayerWalkDust()//�ҳ���Ч
    {
        playerWalkDust.Play();
    }

}
