using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer ruby;
    [Header("Balance variables")]
    [SerializeField]
    private float moveSpeed = 1;

    [SerializeField]
    private int HP = 30;
    [SerializeField]
    private int currentHP = 30;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // RunUp
        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("RunBack", true);
            animator.SetBool("RunFront", false);
            animator.SetBool("RunSide", false);
            
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed);
        }
        // RunFront
        if(Input.GetKey(KeyCode.S))
        {
            animator.SetBool("RunBack", false);
            animator.SetBool("RunFront", true);
            animator.SetBool("RunSide", false);
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed);
        }
        // Left , RunSide
        if(Input.GetKey(KeyCode.A))
        {
            ruby.flipX = false;
            animator.SetBool("RunBack", false);
            animator.SetBool("RunFront", false);
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }
        // Right , RunSide
        if(Input.GetKey(KeyCode.D))
        {
            ruby.flipX = true;
            animator.SetBool("RunBack", false);
            animator.SetBool("RunFront", false);
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            if ((currentHP - collision.GetComponent<Hazard>().damageAmount) < 0)
                currentHP = 0;
            else
                currentHP -= collision.GetComponent<Hazard>().damageAmount;
            
            animator.SetTrigger("DamageSide");
            currentHP -= collision.GetComponent<Hazard>().damageAmount;
            animator.SetTrigger("DamageSide");
        }

        if(collision.CompareTag("Heal"))
        {
            currentHP += collision.GetComponent<Heal>().healAmount;
            //activar heal particles

            if ((currentHP + collision.GetComponent<Heal>().healAmount) > HP)
                currentHP = HP;
            else
                currentHP += collision.GetComponent<Heal>().healAmount;
        }

        if(collision.CompareTag("Geometry"))
        {

        }
    }
}
