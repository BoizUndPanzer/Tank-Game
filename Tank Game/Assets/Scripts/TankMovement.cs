using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {
    [Header("Controls")]
    // Check if the player is using a joystick
    public bool joystickControls = true;
    // Check if the player is using tank controls
    public bool tankControls = true;
    [Space]
    
    [Header("Parameters")]
    // How fast the tank moves forward and back.
    public float m_Speed = 12f;  
    // How fast the tank turns in degrees per second.               
    public float m_TurnSpeed = 180f;
    // The name of the input axis for moving forward and back.
    private string m_MovementAxisName;
    // The name of the input axis for turning.
    private string m_TurnAxisName;
    // The name of the input axis for moving left and right              
    private string moveHorizontal; 
    // The name of the input axis for moving up and down             
    private string moveVertical;
    // Reference used to move the tank.
    private Rigidbody m_Rigidbody; 
    // The current value of the movement input.            
    private float m_MovementInputValue; 
    // The current value of the turn input.        
    private float m_TurnInputValue;             
    // The current value of the left/right input.
    private float m_MovementHorizontal; 
    // The current value of the up/down input.        
    private float m_MovementVertical;           

    private void Awake () {
        m_Rigidbody = GetComponent<Rigidbody> ();
    }


    private void OnEnable () {
        if (tankControls) {
            // When the tank is turned on, make sure it's not kinematic.
            m_Rigidbody.isKinematic = false;

            // Also reset the input values.
            m_MovementInputValue = 0f;
            m_TurnInputValue = 0f;
        }
    }


    private void OnDisable () {
        if (tankControls) {
            // When the tank is turned off, set it to kinematic so it stops moving.
            m_Rigidbody.isKinematic = true;
        }
    }


    private void Start () {
        if (joystickControls) {
            // Set Axis for Tank Movement
            m_MovementAxisName = "LeftJoyStickVertical";
            m_TurnAxisName = "LeftJoyStickHorizontal";

            // Set axis for Free Movement
            moveVertical = "LeftJoyStickVertical";
            moveHorizontal = "LeftJoyStickHorizontal";
        }
        else {
            // Set Axis for Tank Movement
            m_MovementAxisName = "Vertical";
            m_TurnAxisName = "Horizontal";

            // Set axis for Free Movement
            moveVertical = "Vertical";
            moveHorizontal = "Horizontal";
        }
    
    }


    private void Update () {
        // Store the value of both input axes.
        m_MovementInputValue = Input.GetAxis (moveVertical);
        m_TurnInputValue = Input.GetAxis (moveHorizontal);

        // Store the value of both input axes.
        m_MovementVertical = Input.GetAxisRaw (moveVertical);
        m_MovementHorizontal = Input.GetAxisRaw (moveHorizontal);
    }

    private void FixedUpdate () {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        TankControls (tankControls);
        Turn (tankControls);
    }

    // Set the player tank to use "Tank Controls" or not
    private void TankControls (bool controls) {
        if (controls) {
            // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
            Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

            // Apply this movement to the rigidbody's position.
            m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        }
        else {
            // "Free movement" code
            Vector3 movement = new Vector3 (m_MovementHorizontal, 0f, m_MovementVertical);
            if (movement.sqrMagnitude > 0f) {
                transform.rotation = Quaternion.LookRotation(movement);
                Vector3 moveVelocity = movement.normalized * m_Speed;
                m_Rigidbody.MovePosition(m_Rigidbody.position + moveVelocity * Time.fixedDeltaTime);
            } 
        }
    }

    // Rotates the tank body when using tank controls
    private void Turn (bool controls) {
        if (controls) {
            // Determine the number of degrees to be turned based on the input, speed and time between frames.
            float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

            // Make this into a rotation in the y axis.
            Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

            // Apply this rotation to the rigidbody's rotation.
            m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
        }
    }
}
