using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    private bool mustFlip;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private LayerMask flipLayer;

    [SerializeField]
    private Collider2D body;

    [SerializeField]
    private float walkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol)
        {
            Patrol();            
        }        
    }

    void Patrol()
    {
        if(body.IsTouchingLayers(flipLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
