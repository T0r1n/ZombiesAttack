using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float fireRate = 10f; 
    private float nextTimeToFire = 0f;

    public AudioSource shoot_A;

    private void Start() {
        shoot_A.Play();
    }
    void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot(){
        
        GameObject bullet = Instantiate(bulletPrefab,FirePoint.position, FirePoint.rotation * Quaternion.Euler(0, 0, 90));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 1f);
    }
}
