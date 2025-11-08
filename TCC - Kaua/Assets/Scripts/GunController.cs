using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform Target;
    private Vector2 TargetPosition;
    private Vector2 GunDirection;

    private float Angle;

    public SpriteRenderer GunSprite;

    public float GunCooldown = 1.5f;
    private bool CanShoot;

    public Transform FirePoint;
    public GameObject Shot;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        TargetPosition = new Vector2(Target.transform.position.x, Target.transform.position.y);
        Shooting();


    }

    private void FixedUpdate()
    {
        GunDirection = TargetPosition - new Vector2(transform.position.x, transform.position.y);
        Angle = Mathf.Atan2(GunDirection.y, GunDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, Angle);
    }

    void Shooting()
    {
        GunCooldown -= Time.deltaTime;
        if (GunCooldown <= 0 && CanShoot == false)
        {
            GunCooldown = 1;
            CanShoot = true;
        }

        if (CanShoot == true)
        {
            Instantiate(Shot, FirePoint.position, FirePoint.rotation);
            CanShoot = false;
        }
    }
}
