using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject[] Enemies;

    void Start()
    {
        Transition();
        Destroy(this.gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Transition()
    {
        Invoke("SpawnEnemy", 0.5f);
    }
    void SpawnEnemy()
    {
        Instantiate(Enemies[Random.Range(0, Enemies.Length)], this.gameObject.transform.position, Quaternion.identity);
    }
}
