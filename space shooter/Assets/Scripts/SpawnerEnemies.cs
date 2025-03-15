using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    [SerializeField] int maxEnemiesAlive;

    [SerializeField] float forceSpawn;

    [Header("Enemies")]
    [SerializeField] GameObject prefabEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(EnemiesAlive);

        if(EnemiesAlive < maxEnemiesAlive)
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        GameObject enemy = Instantiate(prefabEnemy, transform.position, transform.rotation);
        //Jogar o objeto um pouco para o lado

        Rigidbody2D rbEnemy = enemy.GetComponent<Rigidbody2D>();

        
        forceSpawn = Random.Range(-100, 100);
        rbEnemy.AddForce(transform.right * forceSpawn);
        EnemiesAlive++;
       
    }
}
