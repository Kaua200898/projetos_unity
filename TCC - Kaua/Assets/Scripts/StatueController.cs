using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueController : MonoBehaviour
{
    private bool PlayerDetected = false;
    private Animator anim;

    public Transform []Spawners;
    public GameObject []Enemies;     
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("PlayerDetected", PlayerDetected);
        Spawner();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDetected = true;
    }

    void Spawner()
    {
        if (PlayerDetected)
        {
            Instantiate(Enemies[Random.Range(0, 1)], Spawners[0].position, Quaternion.identity);
            Instantiate(Enemies[Random.Range(0, 1)], Spawners[1].position, Quaternion.identity);
            Instantiate(Enemies[Random.Range(0, 1)], Spawners[2].position, Quaternion.identity);
            PlayerDetected = false;
        }
    }
}
