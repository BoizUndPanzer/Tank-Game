using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour {
    [Header("Shooting")]
    public GameObject tankBarrel;
    public GameObject bulletPrefab;
    // Set rate at which player can shoot projectiles
    public float fireRate = 3f;
    // Set number of bullets allowed on screen at a time
    public int maxBulletsOnScreen = 5;  
    public bool canShoot = true;
    // Track number of bullets on screen
    private int numBullet = 0;
    private GameObject[] getCount;
    // Track the time a projectile is shot
    private float shootingTime;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("A_Button") || Input.GetButtonDown("Fire1")) {
            Shoot(bulletPrefab, tankBarrel);
        }
        limitProjectileNumber();
    }

    private void Shoot (GameObject projectile, GameObject barrel) {
        if ((Time.time > shootingTime) && canShoot == true) {
            shootingTime = Time.time + fireRate;
            // Create an instance of a bullet
            projectile = Instantiate(bulletPrefab);
            // Set tag to the instance so that we can count the number of instances
            projectile.tag = ("P1_Bullet");
            // Set the bullet's rotation to the barrel's rotation
            projectile.transform.rotation = barrel.transform.rotation;
            // Set the bullet's position to the tip of the barrel
            projectile.transform.position = barrel.transform.position + (barrel.transform.forward * 2f);
            //  Destroy the projectile after x amount of seconds
            Destroy(projectile, 2f);
        }
    }

    private void limitProjectileNumber () {
        getCount = GameObject.FindGameObjectsWithTag ("P1_Bullet");
        if (getCount.Length >= maxBulletsOnScreen) {
            canShoot = false;
        }
        else {
            canShoot = true;
        }
    }
}
