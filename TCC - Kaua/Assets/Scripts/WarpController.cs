using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpController : MonoBehaviour
{
    public GameObject Statue;
    public bool IsOpen = false;


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
                    Debug.Log("Abrir");
                    Destroy(this.gameObject);
                }

                if (Enemies.Length == 0)
                {
                    IsOpen = true;
                   
                }
            }
        }
    }
}
