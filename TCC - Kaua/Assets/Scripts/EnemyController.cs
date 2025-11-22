using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float MoveSpeed; 
    private Rigidbody2D rb;
    private Animator anim;

    public Transform Enemy;
    public Transform Target;

    public string EnemyType;

    public GameObject Saw;
    private bool SawInvoked;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        MoveSpeed = Random.Range(2, 3);

        Enemy = this.gameObject.transform;
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

    void Transforming()
    {
        if (EnemyType == "Enemy3")
        {
            MoveSpeed = 0;
            bool PlayerIsInRange = true;
            anim.SetBool("PlayerDetected", PlayerIsInRange);
            Invoke("TurnIntoASaw", 1);
        }
    }

    void TurnIntoASaw()
    {
        if (SawInvoked == false) { Instantiate(Saw, Enemy.transform.position, Quaternion.identity); }
        SawInvoked = true;
        Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && EnemyType != "Enemy3")
        {
            collision.GetComponentInParent<PlayerController>().GiveDamageInPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SimpleShot" && EnemyType != "Enemy3")
        {
            Destroy(this.gameObject);
        }
        else
        {
            if (collision.tag == "Player" && EnemyType == "Enemy3")
            {
                Transforming();
            }
        }

    }
}
