using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour {
    [Header("Shooting")]
    public GameObject tankBarrel;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Shoot(bulletPrefab, tankBarrel);
    }

    private void Shoot (GameObject projectile, GameObject barrel) {
        // If the player presses the "Fire1" button
        if (Input.GetButtonDown("Fire1")) {
            // Create an instance of a bullet
            projectile = Instantiate(bulletPrefab);
            // Set the bullet's rotation to the barrel's rotation
            projectile.transform.rotation = barrel.transform.rotation;
            // Set the bullet's position to the tip of the barrel
            projectile.transform.position = barrel.transform.position + (barrel.transform.forward * 2f);
            //  Destroy the projectile after x amount of seconds
            Destroy(projectile, 3f);
        }
    }
}
