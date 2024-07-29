using System;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float cooldown = 0;
    private AudioManager audioManager;
    private float FireRate;
    public Weapon(float fireRate) {
        FireRate = fireRate;
    }

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
     
    public void Shoot() {
        cooldown -= Time.deltaTime;

        if(cooldown < 0) {
            cooldown = FireRate;
            
            var fire = Input.GetKey(KeyCode.Space);
            if(fire) {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                audioManager.ShootSound();
            }
        }
    }
    
}