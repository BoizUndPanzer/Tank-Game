﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour {
    [Header("Shooting")]
    // Reference to the Tank Barrel
    public Transform tankBarrel;
    // Reference to the Bullet Prefab
    public GameObject bulletPrefab;
    // Set rate at which player can shoot projectiles
    public float fireRate = 3f;
    // Set number of bullets allowed on screen at a time
    public int maxBulletsOnScreen = 5;  
    // Shooting Audio
    public AudioSource snd_shoot;
    // Check wether the player is allowed to shoot
    private bool canShoot = true;
    // Track number of bullets on screen
    private int numBullet = 0;
    // Set array that holds GameObjects (Used for counting number of bullets)
    private GameObject[] getCount;
    // Track the time a projectile is shot
    private float shootingTime;
    // Get reference to TankMovement Script
    private TankMovement TankMovement;
    public GameObject particle;
    // Set Controls according to operating system
    private char OS;

    void Awake() {
        OS = SystemInfo.operatingSystem[0];
    }

    void Start() {
        TankMovement = GetComponent<TankMovement>();
    }

    void Update()
    {
        if ((Input.GetAxis(OS + "P" + TankMovement.m_PlayerNumber + "RT") > 0) || (Input.GetKeyDown("space")))
        {
            Shoot(bulletPrefab, tankBarrel);
            
        }
        limitProjectileNumber();
    }

    // Main shooting function.  Simply creates a bullet at a given rate.
    private void Shoot (GameObject projectile, Transform barrel) {
        Vector3 spawnPos = new Vector3(0,1,0);
        // Check if the time the player shot last is greater than the time of the current frame
        if ((Time.time > shootingTime) && canShoot == true) {
            shootingTime = Time.time + fireRate;
            // Create an instance of a bullet
            projectile = Instantiate(bulletPrefab, (barrel.position + spawnPos + (barrel.forward * 5.5f)), barrel.rotation);
            PlaySound(snd_shoot);
            EmitParticle(tankBarrel);
            // Set tag to the instance so that we can count the number of instances
            projectile.tag = ("P" + TankMovement.m_PlayerNumber + "_Bullet");
            // Set the bullet's rotation to the barrel's rotation
            // projectile.transform.rotation = barrel.transform.rotation;
            // // Set the bullet's position to the tip of the barrel
            // projectile.transform.position = barrel.transform.position + (barrel.transform.forward * 2f);
            //  Destroy the projectile after x amount of seconds
            Destroy(projectile, 10f);
        }
    }

    void EmitParticle(Transform barrel) {
        Vector3 spawnPos = new Vector3(0,1,0);
        GameObject shootparticle = Instantiate(particle, (barrel.position + spawnPos + (barrel.forward * 3f)), Quaternion.identity);
        shootparticle.GetComponent<ParticleSystem>().Play();
        Destroy(shootparticle, 3f);
    }

    // Limits the number of projectiles on screen.
    private void limitProjectileNumber () {
        // Count the number of projectiles with the given tag
        getCount = GameObject.FindGameObjectsWithTag ("P" + TankMovement.m_PlayerNumber + "_Bullet");
        // Check if the number of projectiles on the screen is greater than the max amount allowed
        // If it is greater than or equal to then make sure the player can't shoot
        // Otherwise let the player shoot 
        if (getCount.Length >= maxBulletsOnScreen) {
            canShoot = false;
        }
        else {
            canShoot = true;
        }
    }

    void PlaySound(AudioSource sound) {
        sound.Play();
    }
}
