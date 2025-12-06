using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public string PickupType;

    private bool LifePickupPicked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PickupType == "Life" && LifePickupPicked == false)
            {
                collision.GetComponentInParent<PlayerController>().Life += 1;
                LifePickupPicked = true;
                Destroy(this.gameObject);
            }
        }
    }
}
