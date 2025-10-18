using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D rb;

    public int Life;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        float MoveX, MoveY;

        MoveX = Input.GetAxisRaw("Horizontal");
        MoveY = Input.GetAxisRaw("Vertical");

        Vector2 Direction = new Vector2(MoveX, MoveY);
        rb.velocity = MoveSpeed * Direction.normalized;
    }
}
