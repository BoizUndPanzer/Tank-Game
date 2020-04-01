using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 100f;
    private Collider collider;
    public LayerMask collisionMask;

    public int bounceLimit = 2;
    private int bounceNum = 0;

    void Start() {
        collider = GetComponent<Collider>();
    }

    void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter (Collider other) {
        // Debug.Log("Hit");
        // Destroy(gameObject);
        // Vector3 v = Vector3.Reflect(transform.up, other.contacts[0].normal);
        // float rot = 90 - Mathf.Atan2(v.z, v.x) * Mathf.Rad2Deg;
        // transform.eulerAngles = new Vector3(90, rot, 0);
    }

    void OnCollisionEnter(Collision collision) {
        Vector3 v = Vector3.Reflect(transform.forward , collision.contacts[0].normal);
        float rot = 90 - Mathf.Atan2(v.z, v.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, rot, 0);
        
        bounceNum += 1;
        Debug.Log(bounceNum);

        if (collision.collider.tag == "Player") {
            Debug.Log ("Player");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "P1_Bullet" || collision.gameObject.tag == "P2_Bullet" || collision.gameObject.tag == "P3_Bullet" || collision.gameObject.tag == "P4_Bullet") {
            Debug.Log("Bullet");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (bounceNum >= bounceLimit) {
            Destroy(gameObject);
        }
    }
}
