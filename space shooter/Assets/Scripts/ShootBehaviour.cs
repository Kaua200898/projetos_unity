using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [Header("Atributtes")]
    [SerializeField] float speedShoot = 500f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speedShoot * Time.deltaTime);
    }

    void Update()
    {
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Die();
    }
}
