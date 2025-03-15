using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] int life;
    bool die;

    [Header("Feedback")]
    [SerializeField] GameObject dieEffect;

    [Header("Physics")]
    Rigidbody2D rb;

    [Header("Prefabs")]
    [SerializeField] GameObject prefabCoin;

    // Start is called before the first frame update
    void Start()
    {
        die = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(life <= 0)
        {
            Die();

            if (die)
            {
                SpawnerEnemies.EnemiesAlive--;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Shoot")
        {
            life -= 1;
            Destroy(collision.gameObject);
        }
    }

    void Die()
    {
        die = true;

        //Feedback visual
        GameObject effect = Instantiate(dieEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        GameObject coin = Instantiate(prefabCoin, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
