using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public float SawSpeed;
    private float MoveX;
    private float MoveY;

    public bool CollidingDown;
    public bool CollidingUp;
    public bool CollidingLeft;
    public bool CollidingRight;

    public Transform[] Colliders;
    public float Raycast;
    public LayerMask SolidLayer;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float[] MoveNumbers = {-1 , 1};
        int RandomNumber = Random.Range(0, MoveNumbers.Length);

        MoveX = MoveNumbers[RandomNumber];
        MoveY = MoveNumbers[RandomNumber];
    }

    
    void Update()
    {
        Move();
        Bounce();
    }

    void Move()
    {
        Vector2 Direction = new Vector2(MoveX, MoveY);
        rb.velocity = SawSpeed * Direction.normalized;
    }

    void Bounce()
    {
        CollidingDown = Physics2D.OverlapCircle(Colliders[0].position, Raycast, SolidLayer);
        CollidingUp = Physics2D.OverlapCircle(Colliders[1].position, Raycast, SolidLayer);
        CollidingLeft = Physics2D.OverlapCircle(Colliders[2].position, Raycast, SolidLayer);
        CollidingRight = Physics2D.OverlapCircle(Colliders[3].position, Raycast, SolidLayer);

        if (CollidingDown) { MoveY = 1; }
        if (CollidingUp) { MoveY = -1; }
        if (CollidingLeft) { MoveX = 1; }
        if (CollidingRight) { MoveX = -1; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponentInParent<PlayerController>().GiveDamageInPlayer();
        }
    }
}
