using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Controler : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 lookDirection = new Vector2(1, 0);//��ʼ����
    private bool isLookUp=false;
    private bool isRunning = false;
    

    public float moveSpeed = 3f;


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
    }
     private void Movement()
    {
        Vector2 position = transform.position;
        //float v = Input.GetAxisRaw("Vertical");//��ֱ
        //float v = Input.GetKeyDown(KeyCode.W) ? 1f:0f ;
        float v = isLookUp ? 1f : 0f;
        float h = Input.GetAxisRaw("Horizontal");//ˮƽ
        Vector2 move = new Vector2(h, 0);

        if (!Mathf.Approximately(move.x, 0) && Mathf.Approximately(v, 0))//�������������Ϊ0
        {
            lookDirection.Set(move.x, v);
            lookDirection.Normalize();//��һ�������ش�СΪ1������������Ҫ����ʵ�ʵĴ�С��ֻ��Ҫ����������
            isRunning = true;
            animator.SetBool("isRun", true);

        }
        else
        {
            isRunning = false;
            animator.SetBool("isRun", false);
        }
        animator.SetFloat("lookDirection", lookDirection.x);
        position = position + moveSpeed * move * Time.fixedDeltaTime;
        rb.MovePosition(position);
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            isLookUp = true;
            animator.SetBool("isLookUp", true);
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            isLookUp = false;
            animator.SetBool("isLookUp", false);
        }
    }
}
