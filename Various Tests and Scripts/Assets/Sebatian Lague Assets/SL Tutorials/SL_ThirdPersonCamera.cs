﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SL_ThirdPersonCamera : MonoBehaviour {

    public bool lockCursor;
    public float mouseSensitivity;
    public Transform target;
    public float distanceFromTarget = 2;
    public float pitchMin = -45;
    public float pitchMax = 85;

    public float rotationSmoothTime = 0.12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    float yaw;
    float pitch;

    void Start()
    {
        if(lockCursor) //hides the cursor and uses esc to let it become visible
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

	void LateUpdate ()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity; //sets the varible yaw,the y axis, to the axis from the input manger "Mouse X"
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity; //sets the variable pitch, the x axis, to the y value given by the mouse
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax); //sets the value of the variable between the pitchMin value and the pitchMax value

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime); //function to smooth the camera

        transform.eulerAngles = currentRotation; //sets the angles of the transform component this script is attached to (the main camera) to the value that I want for angles 

        transform.position = target.position - transform.forward * distanceFromTarget; //sets the position of the object to be target position 
	}
}
