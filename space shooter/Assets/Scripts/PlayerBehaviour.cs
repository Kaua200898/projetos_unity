using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Game Manager")]
    [SerializeField] GameManager gameManager;

    [Header("Attributes")]
    Vector3 mousePosition;
    Rigidbody2D rb;
    Vector2 direction;
    [SerializeField] float moveSpeed = 1500f;

    [Header("Shoot")]
    [SerializeField] GameObject shootPrefab;
    float countdownShoot = 0f;
    [SerializeField] float timeToShoot = 0.5f;

    [Header("Feedback")]
    [SerializeField] GameObject dieEffectPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Tempo real
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Shoot();
    }

    void Movement()
    {
        if(Input.GetMouseButton(0))
        {
            //Posição do mouse em relação a tela do jogo (câmera do jogo)
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Direção para à qual o objeto deve ir sem teleportar para o mouse
            direction = (mousePosition - transform.position).normalized;
            //Velocidade de movimentação da nave de acordo com sua direção
            rb.velocity = new Vector2(direction.x * moveSpeed * Time.deltaTime, 0);
        }
        else
        {
            //Parar a nave ao soltar o dedo ou o mouse
            rb.velocity = Vector2.zero;
        }
    }

    void Shoot()
    {
        //Ao clicar com o botão esquerdo do mouse
        if(Input.GetMouseButton(0))
        {

            if(countdownShoot >= timeToShoot)
            {
                GameObject shoot = Instantiate(shootPrefab, transform.position, Quaternion.identity);
                countdownShoot = 0f;
            }  
        }

        countdownShoot += Time.deltaTime;
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameManager.GameOver();

            //Feedback visual
            GameObject effect = Instantiate(dieEffectPlayer, transform.position, Quaternion.identity);
            Destroy(effect, 5f);

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Coin")
        {
            GameManager.Points++;
            Destroy(collision.gameObject);
        }
    }
}
