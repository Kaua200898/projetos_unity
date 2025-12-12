using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameObject Player;

    public float PlayerLife;
    public float PlayerMaxLife;
    public GameObject PlayerGun;
    public string PlayerGunType;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        PlayerMaxLife = 10;
        PlayerLife = PlayerMaxLife;
        PlayerGunType = "Pistol";
    }

    void Update()
    {
        PlayerGun = GameObject.FindGameObjectWithTag("PlayerGun");
    }

    public void PlayerDamageManager(int DamageAmount)
    {
        PlayerLife -= DamageAmount;
    }

    public void ChangeGunManager(string GunName)
    {
        PlayerGunType = GunName;
    }

    public void ResetPlayerStatus()
    {
        PlayerMaxLife = 10;
        PlayerLife = PlayerMaxLife;
        PlayerGunType = "Pistol";
    }
}
