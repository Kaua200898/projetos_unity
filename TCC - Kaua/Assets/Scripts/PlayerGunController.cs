using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    private Vector2 MousePos;
    private Vector2 GunDirection;

    private float Angle;

    public SpriteRenderer GunSprite;

    public float GunCooldown = 1.5f;
    private bool CanShoot = true;

    public Transform FirePoint;
    public GameObject Shot;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Shoot();
    }

    private void FixedUpdate()
    {
        GunDirection = MousePos - new Vector2(transform.position.x, transform.position.y);
        Angle = Mathf.Atan2(GunDirection.y, GunDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, Angle);

        if (Angle > -180 && Angle < 0)
        {
            GunSprite.flipY = false;
        }
        else
        {
            GunSprite.flipY = true;
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && CanShoot == true)
        {
            CanShoot = false;
            Instantiate(Shot, FirePoint.position, FirePoint.rotation);
            Invoke("CD", GunCooldown);

        }
    }
    void CD()
    {
        CanShoot = true;
    }

}
