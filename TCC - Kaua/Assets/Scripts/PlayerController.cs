using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;
using JetBrains.Annotations;

public class PlayerController : MonoBehaviour
{
    [Header("Velocidades")]
    public float MoveSpeed;
    public float DashSpeed;
    private float Speed;

    [Header("Propriedades do Dash")]
    public float DashCooldown = 1;
    private bool InDash;
    public Image DashUI;
    private float DashCooldownUI = 1;

    private Rigidbody2D rb;
    private Animator anim;
    private TrailRenderer tr;
    private CinemachineImpulseSource cis;

    [Header("Arma")]
    public GameObject Gun;

    private float MoveX, MoveY;

    [Header("Propriedades da Vida")]
    public float Life;
    public float MaxLife = 10;
    public Image LifeUI;

    [Header("Propriedades do Dano")]
    public float DamageCooldown;
    public bool CanTakeDamage = true;
    public bool IsDead = false;

    [Header("Audio")]
    public AudioSource HitSound;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tr = GetComponent<TrailRenderer>();
        cis = GetComponent<CinemachineImpulseSource>();

        tr.emitting = false;

        Speed = MoveSpeed;

        MaxLife = Life = GameManager.instance.PlayerMaxLife;
        Life = GameManager.instance.PlayerLife;
        Gun.GetComponentInParent<PlayerGunController>().GunType = GameManager.instance.PlayerGunType;

    }


    void Update()
    {
        Gun = GameManager.instance.PlayerGun;

        Move();
        Animation();
        Damage();
        HealthUIupdate();
        DashUIupdate();
    }

    void Move()
    {
        //Movimentação Normal
        if (Speed == MoveSpeed)
        {
            MoveX = Input.GetAxisRaw("Horizontal");
            MoveY = Input.GetAxisRaw("Vertical");
        }

        Vector2 Direction = new Vector2(MoveX, MoveY);
        rb.velocity = Speed * Direction.normalized;

        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && Direction != Vector2.zero && InDash == false && IsDead == false)
        {
            InDash = true;
            CanTakeDamage = false;
            Speed = DashSpeed;
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.magenta, Color.clear, 0.25f);
            tr.emitting = true;
            Invoke("AfterDash", 0.5f);
        }
    }

    void AfterDash()
    {
        //Depois que ele deu o dash

        CanTakeDamage = true;
        Speed = MoveSpeed;
        GetComponent<SpriteRenderer>().color = Color.white;
        tr.emitting = false;
        Invoke("EndDash", DashCooldown);
    }

    void EndDash()
    {
        InDash = false;
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

        anim.SetBool("IsDead", IsDead);
    }

    void HealthUIupdate()
    {
        LifeUI.fillAmount = Life / MaxLife;
    }

    void DashUIupdate()
    {
        DashUI.fillAmount = DashCooldownUI;

        if (Speed == DashSpeed)
        {
            if (DashCooldownUI > 0) DashCooldownUI -= 0.01f;
        } 
        else
        {
            if (DashCooldownUI < 1)DashCooldownUI += 0.005f;
        }
    }
    void Damage()
    {
        if (CanTakeDamage == false)
        {
            if (InDash == false)
            {
                GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.clear, 0.25f);
                DamageCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (InDash == false) { GetComponent<SpriteRenderer>().color = Color.white; }
        }

        if (DamageCooldown <= 0)
        {
            CanTakeDamage = true;
            DamageCooldown = 0;
        }

        //Morte do Player
        if (Life <= 0)
        {
            IsDead = true;

            if (IsDead == true)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                Speed = 0;
                MoveSpeed = 0;
                DashSpeed = 0;
                Destroy(Gun);
                Invoke("GameOver", 1);
            }
        }
    }

    public void GiveDamageInPlayer(int DamageAmount)
    {

        //Tomar dano e perder vida;
        if (CanTakeDamage == true)
        {
            Life -= DamageAmount;
            GameManager.instance.PlayerDamageManager(DamageAmount);
            HitSound.Play(); //Tocar o som de dano
            CameraShakeManager.instance.CameraShake(cis); //Tremer a câmera
            CanTakeDamage = false;
            DamageCooldown = 2;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
