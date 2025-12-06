using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpController : MonoBehaviour
{
    public GameObject Statue;
    public bool IsOpen = false;

    public GameObject NextStageManager;

    void Start()
    {
        Statue = GameObject.FindGameObjectWithTag("Statue");
    }


    void FixedUpdate()
    {

        if (tag == "BlockedWarp")
        {
            if (Statue.GetComponentInParent<StatueController>().PlayerHasBeenDetected)
            {
                Invoke("CountEnemies", 0.5f);
            }
        }
        else if (tag == "Warp")
        {
            if (Statue.GetComponentInParent<StatueController>().PlayerHasBeenDetected)
            {
                Invoke("OpenDoor", 0.5f);
            }
        }
    }

    void CountEnemies()
    {

        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (IsOpen)
        {
            Destroy(this.gameObject);
        }

        if (Enemies.Length <= 0)
        {
            IsOpen = true;

        }
    }

    void OpenDoor()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (Enemies.Length <= 0)
        {
            IsOpen = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tag == "Warp" && IsOpen == true)
        {
            NextStageManager.GetComponentInParent<NextStageManager>().NextStage();
        }
    }
}
