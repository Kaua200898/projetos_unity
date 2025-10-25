using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D rb;
    private Animator anim;

    private float MoveX, MoveY;

    public float Life;
    public float MaxLife = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Life = MaxLife;
    }


    void Update()
    {
        Move();
        Animation();
        Death();

    }

    void Move()
    {
        MoveX = Input.GetAxisRaw("Horizontal");
        MoveY = Input.GetAxisRaw("Vertical");

        Vector2 Direction = new Vector2(MoveX, MoveY);
        rb.velocity = MoveSpeed * Direction.normalized;
    }

    void ResetAnimationLayers()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 0);
        anim.SetLayerWeight(2, 0);
        anim.SetLayerWeight(3, 0);
    }

    void Animation()
    {
        anim.SetFloat("Horizontal", MoveX);
        anim.SetFloat("Vertical", MoveY);

        if (anim.GetFloat("Horizontal") == 1)
        {
            ResetAnimationLayers();
            anim.SetLayerWeight(3, 1);
        }
        else if (anim.GetFloat("Horizontal") == -1)
        {
            ResetAnimationLayers();
            anim.SetLayerWeight(2, 1);
        }

        if (anim.GetFloat("Vertical") == 1 && anim.GetFloat("Horizontal") == 0)
        {
            ResetAnimationLayers();
            anim.SetLayerWeight(1, 1);
        }
        else if (anim.GetFloat("Vertical") == -1 && anim.GetFloat("Horizontal") == 0)
        {
            ResetAnimationLayers();
            anim.SetLayerWeight(0, 1);
        }
    }
    void Death()
    {
        if (Life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
