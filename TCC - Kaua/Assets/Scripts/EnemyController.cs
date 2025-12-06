using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Velocidade")]
    public float MoveSpeed; 

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    [Header("Propriedades do Inimigo")]
    public Transform Enemy;
    public Transform Target;
    public string EnemyType;
    public bool HaveGun;

    [Header("Propriedades da Vida")]
    public int EnemyLife;
    public GameObject DeathEffect;

    [Header("Itens")]
    public GameObject Saw;
    private bool SawInvoked;

    public GameObject Drop;
    private int RandomValue;

    void Start()
    {
        RandomValue = Random.Range(0, 2);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

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

        if (EnemyType == "Enemy2")
        {
            HaveGun = true;
        }

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
        if (collision.tag == "Player" && EnemyType != "Enemy3" && !HaveGun)
        {
            collision.GetComponentInParent<PlayerController>().GiveDamageInPlayer(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SimpleShot" && EnemyType != "Enemy3")
        {
            Damage();
        }
        else
        {
            if (collision.tag == "Player" && EnemyType == "Enemy3")
            {
                Transforming();
            }
        }

    }

    void Damage()
    {
        EnemyLife--;
        sr.color = Color.magenta;
        Invoke("DamageGived", 0.1f);

        if (EnemyLife <= 0)
        {
            Instantiate(DeathEffect, Enemy.position, Quaternion.identity);
            Destroy(this.gameObject);

            if (EnemyType == "Enemy4") { Instantiate(Drop, Enemy.position, Quaternion.identity); }
            else if (EnemyType != "Enemy4" && Drop != null)
            {
                int Value = RandomValue;
                Debug.Log(Value);
                if (Value > 0) Instantiate(Drop, Enemy.position, Quaternion.identity);
            }
        }
    }

    void DamageGived()
    {
        sr.color = Color.white;
    }

    
}
