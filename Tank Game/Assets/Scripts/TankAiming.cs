using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAiming : MonoBehaviour
{
    public float rotateSpeed = 5f;
    private Transform barrel;
    private float rotateHorizontal;
    private float rotateVertical;
    private TankMovement TankMovement;
    // Set Controls according to operating system
    private char OS;

    void Awake() {
        OS = SystemInfo.operatingSystem[0];
    }
    void Start() {
        TankMovement = GetComponent<TankMovement>();
        barrel = this.gameObject.transform.GetChild(0);
    }

    void Update() {
        // rotateVertical = Input.GetAxisRaw ("AimVertical");
        // rotateHorizontal = Input.GetAxisRaw ("AimHorizontal");
        rotateVertical = Input.GetAxis (OS + "P" + TankMovement.m_PlayerNumber + "RSV");
        rotateHorizontal = Input.GetAxis (OS + "P" + TankMovement.m_PlayerNumber + "RSH");
        RotateBarrel();
    }

    void RotateBarrel() {
        Vector3 direction = new Vector3 (rotateHorizontal, 0f, rotateVertical);
        Quaternion targetRotation = Quaternion.Euler(direction);
        if (direction.sqrMagnitude > 0f) {
                // barrel.rotation = Vector3.RotateTowards(barrel.rotation, direction, rotateSpeed * Time.deltaTime, 0.0f);
                barrel.rotation = Quaternion.LookRotation(Vector3.RotateTowards(barrel.forward, direction, rotateSpeed * Time.deltaTime, 0.0f));

                // Debug.Log(rotateHorizontal);
                // Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                // Vector3 moveVelocity = movement.normalized * m_Speed;
                // m_Rigidbody.MovePosition(m_Rigidbody.position + moveVelocity * Time.fixedDeltaTime);
            }
        // barrel.transform.rotation = Quaternion.LookRotation(direction);
    }
}
