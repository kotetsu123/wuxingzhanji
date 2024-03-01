using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    
    //private Animation animation;
    private Animator animator;

    

    void Start()
    {
      // animation = GetComponent<Animation>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        movementTest main = collision.GetComponent<movementTest>();
        if (main != null)
        {
            if (collision.CompareTag("Player"))
            {
                //animation.Play("bonFires");
                animator.SetTrigger("fireOn");
            }
        }
        
    }
}
