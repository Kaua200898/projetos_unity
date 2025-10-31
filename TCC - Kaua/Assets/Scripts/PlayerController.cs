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
    public Image LifeUI;

    public float DamageCooldown;
    public bool CanTakeDamage = true;
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
        Damage();
        HealthUI();

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
    }

    void Animation()
    {
        if (MoveX != 0 || MoveY != 0)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }

            anim.SetFloat("Horizontal", MoveX);
        anim.SetFloat("Vertical", MoveY);

        if (anim.GetFloat("Horizontal") == 1)
        {
            ResetAnimationLayers();
            anim.SetLayerWeight(2, 1);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (anim.GetFloat("Horizontal") == -1)
        {
            ResetAnimationLayers();
            anim.SetLayerWeight(2, 1);
            GetComponent<SpriteRenderer>().flipX = true;
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

    void HealthUI()
    {
        LifeUI.fillAmount = Life / MaxLife;
    }
    void Damage()
    {
        if (CanTakeDamage == false)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.clear, 0.25f);
            DamageCooldown -= Time.deltaTime;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (DamageCooldown <= 0)
        {
            CanTakeDamage = true;
            DamageCooldown = 0;
        }

        if (Life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void GiveDamageInPlayer()
    {
        if (CanTakeDamage == true)
        {
            Life--;
            CanTakeDamage = false;
            DamageCooldown = 2;
        }
    }
}
