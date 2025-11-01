using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float ShotSpeed;
    public float DestroyIn;
    void Start()
    {
        Destroy(this.gameObject, DestroyIn);
    }


    private void FixedUpdate()
    {
        transform.Translate(transform.up * ShotSpeed * Time.fixedDeltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (this.gameObject.tag != "SimpleShot")
            {
                collision.GetComponentInParent<PlayerController>().GiveDamageInPlayer();
                if (collision.GetComponentInParent<PlayerController>().CanTakeDamage)
                {
                    Destroy(this.gameObject);
                }
            }
        
        }
        else if (collision.tag == "Enemy")
        {
            if (this.gameObject.tag == "SimpleShot")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
