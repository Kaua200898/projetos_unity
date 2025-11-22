using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpController : MonoBehaviour
{
    public GameObject Statue;
    public bool IsOpen = false;

    public string StageName;

    void Start()
    {
        Statue = GameObject.FindGameObjectWithTag("Statue");
    }


    void Update()
    {

        if (tag == "BlockedWarp")
        {
            if (Statue.GetComponentInParent<StatueController>().PlayerHasBeenDetected)
            {
                GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");

                if (IsOpen)
                {
                    Destroy(this.gameObject);
                }

                if (Enemies.Length == 0)
                {
                    IsOpen = true;
                   
                }
            }
        }

        if (tag == "Warp")
        {
            if (Statue.GetComponentInParent<StatueController>().PlayerHasBeenDetected)
            {
                GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");

                if (Enemies.Length == 0)
                {
                    IsOpen = true;

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tag == "Warp" && IsOpen == true)
        {
            SceneManager.LoadScene(StageName);
        }
    }
}
