using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrLookMovement : MonoBehaviour
{
    public Transform vrCamera;
    public float toggleAngle;
    public float speedForward;
    public float speedBackward;
    public bool moveForward;
    public bool moveBackward; // Add a boolean for backward movement

    private CharacterController cc;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is looking forward
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForward = true;
            moveBackward = false; // Make sure to set moveBackward to false if moving forward
        }
        // Check if the player is looking backward
        else if (vrCamera.eulerAngles.x >= 270.0f && vrCamera.eulerAngles.x < 360.0f - toggleAngle)
        {
            moveForward = false;
            moveBackward = true;
        }
        else
        {
            moveForward = false;
            moveBackward = false;
        }

        // Move the player forward or backward based on the boolean flags
        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speedForward);
        }
        else if (moveBackward)
        {
            Vector3 backward = vrCamera.TransformDirection(Vector3.back); // Calculate backward direction
            cc.SimpleMove(backward * speedBackward);
        }
    }
}

