using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destroyedTank;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "P1_Bullet" || collision.gameObject.tag == "P2_Bullet" || collision.gameObject.tag == "P3_Bullet" || collision.gameObject.tag == "P4_Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            var pos = transform.position;
            var rot = transform.rotation;
            var rotTop = rot;
            rot *= Quaternion.Euler(0, 90, 0);
            rotTop *= Quaternion.Euler(0, 0, 0);

            GameObject tank = Instantiate(destroyedTank, transform.position, rot);
            Debug.Log(pos);
            Destroy(tank, 3f);
        }
    }

}
