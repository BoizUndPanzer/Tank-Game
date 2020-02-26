using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour {
    [Header("Shooting")]
    public GameObject tankBarrel;
    public GameObject bulletPrefab;
    public float fireRate = 3f;    // Set rate at which player can shoot projectiles
    private float shootingTime;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("A_Button") || Input.GetButtonDown("Fire1")) {
            Shoot(bulletPrefab, tankBarrel);
        }
    }

    private void Shoot (GameObject projectile, GameObject barrel) {
        if (Time.time > shootingTime) {
            shootingTime = Time.time + fireRate;
            // Create an instance of a bullet
            projectile = Instantiate(bulletPrefab);
            // Set the bullet's rotation to the barrel's rotation
            projectile.transform.rotation = barrel.transform.rotation;
            // Set the bullet's position to the tip of the barrel
            projectile.transform.position = barrel.transform.position + (barrel.transform.forward * 2f);
            //  Destroy the projectile after x amount of seconds
            Destroy(projectile, 2f);
        }
    }
}
