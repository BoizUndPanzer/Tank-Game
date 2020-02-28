using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAiming : MonoBehaviour
{
    private Transform barrel;
    private float rotateHorizontal;
    private float rotateVertical;
    void Start() {
        barrel = this.gameObject.transform.GetChild(0);


    }

    void Update() {
        // rotateVertical = Input.GetAxisRaw ("AimVertical");
        // rotateHorizontal = Input.GetAxisRaw ("AimHorizontal");
        rotateVertical = Input.GetAxisRaw ("RightJoyStickVertical");
        rotateHorizontal = Input.GetAxisRaw ("RightJoyStickHorizontal");

        RotateBarrel();
    }

    void RotateBarrel() {
        Vector3 direction = new Vector3 (rotateHorizontal, 0f, rotateVertical);
        if (direction.sqrMagnitude > 0f) {
                barrel.transform.rotation = Quaternion.LookRotation(direction);
                // Vector3 moveVelocity = movement.normalized * m_Speed;
                // m_Rigidbody.MovePosition(m_Rigidbody.position + moveVelocity * Time.fixedDeltaTime);
            }
        // barrel.transform.rotation = Quaternion.LookRotation(direction);
    }
}
