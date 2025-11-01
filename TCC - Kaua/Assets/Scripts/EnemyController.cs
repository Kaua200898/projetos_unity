using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float MoveSpeed; 
    private Rigidbody2D rb;
    private Animator anim;

    public Transform Enemy;
    public Transform Target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        float MoveX, MoveY;

        if (Enemy.position.x < Target.position.x)
        {
            MoveX = 1;
        }
        else { MoveX = -1; }

        if (Enemy.position.y < Target.position.y)
        {
            MoveY = 1;
        }
        else { MoveY = -1; }

        Vector2 Direction = new Vector2(MoveX, MoveY);
        rb.velocity = MoveSpeed * Direction.normalized;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponentInParent<PlayerController>().GiveDamageInPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SimpleShot")
        {
            Destroy(this.gameObject);
        }
    }
}
