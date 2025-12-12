using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public string PickupType;
    public AudioSource PickupSound;

    private bool PickupPicked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (PickupType == "Life" && PickupPicked == false)
            {
                float PlayerLife = collision.GetComponentInParent<PlayerController>().Life;
                float PlayerMaxLife = collision.GetComponentInParent<PlayerController>().MaxLife;

                if (PlayerLife < PlayerMaxLife)
                {
                    collision.GetComponentInParent<PlayerController>().Life += 1;
                    GameManager.instance.PlayerLife += 1;
                    PickupPicked = true;
                    PickupSound.Play();
                    Destroy(this.gameObject, PickupSound.clip.length);
                }
            }

            if (PickupType == "Uzi")
            {
                collision.GetComponentInParent<PlayerController>().Gun.GetComponentInParent<PlayerGunController>().ChangeGun("Uzi");
                PickupSound.Play();
                Destroy(this.gameObject, PickupSound.clip.length);
            }
        }
    }
}
