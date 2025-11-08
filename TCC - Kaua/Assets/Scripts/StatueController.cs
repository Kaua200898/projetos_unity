using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueController : MonoBehaviour
{
    private bool PlayerDetected = false;
    public bool PlayerHasBeenDetected = false;
    private Animator anim;

    public GameObject []Spawners;
    public GameObject []Enemies;

    void Start()
    {
        anim = GetComponent<Animator>();

        Spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("PlayerDetected", PlayerDetected);

        Spawner();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && PlayerHasBeenDetected == false)
        {
            PlayerDetected = true;
            PlayerHasBeenDetected = true;
        }
    }

    void Spawner()
    {
        if (PlayerDetected)
        {
            for(int i = 0; i < Spawners.Length; i++)
            {
                Instantiate(Enemies[Random.Range(0, Enemies.Length)], Spawners[i].transform.position, Quaternion.identity);
            }


            PlayerDetected = false;
        }
    }
}
