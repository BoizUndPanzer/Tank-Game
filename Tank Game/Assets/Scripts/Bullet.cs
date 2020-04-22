using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    private Collider collider;

    public GameObject sound;
    public GameObject particle;
    public GameObject explosionSound;

    public int bounceLimit = 2;
    private int bounceNum = 0;

    void Start()
    {
        collider = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 v = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
        float rot = 90 - Mathf.Atan2(v.z, v.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, rot, 0);
        bounceNum += 1;
        if (collision.collider.tag != "Player")
        {
            GameObject snd_bounce = Instantiate(sound, transform.position, Quaternion.identity);
            Destroy(snd_bounce, 1f);
        }
        GameObject shockWave = Instantiate(particle, transform.position, Quaternion.identity);
        shockWave.GetComponent<ParticleSystem>().Play();
        Destroy(shockWave, 3f);
        if (collision.collider.tag == "Player")
        {
            GameObject snd_explosion = Instantiate(explosionSound, transform.position, Quaternion.identity);
            Destroy(snd_explosion, 1f);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.contacts[0].otherCollider.name == "Barrel")
        {
            GameObject snd_explosion = Instantiate(explosionSound, transform.position, Quaternion.identity);
            Destroy(snd_explosion, 1f);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        // if (collision.collider.tag == "Wall") {
        //     bounceNum += 1;
        //     Debug.Log (collision.gameObject.name);
        //     Destroy(gameObject);
        // }

        if (collision.gameObject.tag == "P1_Bullet" || collision.gameObject.tag == "P2_Bullet" || collision.gameObject.tag == "P3_Bullet" || collision.gameObject.tag == "P4_Bullet")
        {
            // Debug.Log("Bullet");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (bounceNum >= bounceLimit)
        {
            Destroy(gameObject);
        }
    }
}
