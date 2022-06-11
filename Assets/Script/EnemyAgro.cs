using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float agroRange;

    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D rb;

    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distant = Vector2.Distance(transform.position, player.position);

        if(distant < agroRange)
        {
            ChasePlayer();
            anim.SetBool("jalan", true);
        }else
        {
            StopChasing();
            anim.SetBool("jalan", false);
        }

        Debug.Log(distant);
    }

    private void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            //-
            rb.velocity = new Vector2(moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = true;

        }else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = false;
            
        }
    }

    private void StopChasing()
    {
        rb.velocity = Vector2.zero;
    }

}
