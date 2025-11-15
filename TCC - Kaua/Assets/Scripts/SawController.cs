using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public float SawSpeed;
    private float MoveX;
    private float MoveY;

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
    }

    void Move()
    {
        Vector2 Direction = new Vector2(MoveX, MoveY);
        rb.velocity = SawSpeed * Direction.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponentInParent<PlayerController>().GiveDamageInPlayer();
        }
    }
}
