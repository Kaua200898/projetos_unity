using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioSource DeathEffect;
    void Start()
    {
        DeathEffect = GetComponent<AudioSource>();
        DeathEffect.Play();
        Destroy(this.gameObject, 0.25f);
    }
}
