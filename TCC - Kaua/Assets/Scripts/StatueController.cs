using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueController : MonoBehaviour
{
    private bool PlayerDetected = false;
    public bool PlayerHasBeenDetected = false;
    private Animator anim;

    public AudioSource SpawnSound;

    public GameObject []Spawners;
    public GameObject []GiantSpawners;
    public GameObject SpawnerBlink;
    public GameObject GiantSpawnerBlink;


    void Start()
    {
        anim = GetComponent<Animator>();

        Spawners = GameObject.FindGameObjectsWithTag("Spawner");
        GiantSpawners = GameObject.FindGameObjectsWithTag("GiantSpawner");
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
            SpawnSound.Play();
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
                Instantiate(SpawnerBlink, Spawners[i].transform.position, Quaternion.identity);
            }

            for (int i = 0; i < GiantSpawners.Length; i++)
            {
                Instantiate(GiantSpawnerBlink, GiantSpawners[i].transform.position, Quaternion.identity);
            }


            PlayerDetected = false;
        }
    }
}
