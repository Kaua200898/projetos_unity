using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject Drop;
    public GameObject DestroyEffect;

    private SpriteRenderer sr;
    public Sprite SpriteClosed;
    public Sprite SpriteOpen;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = SpriteClosed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SimpleShot")
        {
            OpenChest();
            Invoke("DestroyChest", 1);
        }
    }

    void OpenChest()
    {
        sr.sprite = SpriteOpen;
        Instantiate(Drop, this.gameObject.transform.position, Quaternion.identity);
    }

    void DestroyChest()
    {
        Instantiate(DestroyEffect, this.gameObject.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
