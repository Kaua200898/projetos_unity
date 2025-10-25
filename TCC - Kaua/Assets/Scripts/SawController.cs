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

        MoveX = Random.Range(1, -1);
        MoveY = Random.Range(1, -1);
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
}
