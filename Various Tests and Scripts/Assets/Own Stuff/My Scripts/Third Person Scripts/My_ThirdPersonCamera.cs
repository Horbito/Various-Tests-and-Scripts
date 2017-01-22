using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_ThirdPersonCamera : MonoBehaviour {

    public bool lockCursor;
    public float stickSensitivity = 1;
    public Transform target;
    public float distanceFromTarget = 2;
    public float pitchMin = -45;
    public float pitchMax = 85;

    public float rotationSmoothTime = 0.12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    GameObject playerCharacter;
    My_SwitchPOV switchInput;

    float yaw;
    float pitch;

    void Start()
    {
        playerCharacter = GameObject.Find("Player");
        switchInput = playerCharacter.GetComponent<My_SwitchPOV>();
        if (lockCursor) //hides the cursor and uses esc to let it become visible
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void LateUpdate()
    {
        if(switchInput.usingGamepad == true)
        {
            //remember that all axis are set in the input manger
            yaw += Input.GetAxis("Right_Horizontal_Joystick") * stickSensitivity; //sets the varible yaw,the y axis, to the x axis value given by the right joystick
            pitch += Input.GetAxis("Right_Vertical_Joystick") * stickSensitivity; //sets the variable pitch, the x axis, to the y value given by the mouse
            pitch = Mathf.Clamp(pitch, pitchMin, pitchMax); //sets the value of the variable between the pitchMin value and the pitchMax value

            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime); //function to smooth the camera

            transform.eulerAngles = currentRotation; //sets the angles of the transform component this script is attached to (the main camera) to the value that I want for angles 

            transform.position = target.position - transform.forward * distanceFromTarget; //sets the position of the object to be target position 
        }
        if(switchInput.usingKeyboard == true)
        {
            //remember that all axis are set in the input manger
            yaw += Input.GetAxis("Mouse X") * stickSensitivity; //sets the varible yaw,the y axis, to the x axis value given by the right joystick
            pitch += Input.GetAxis("Mouse Y") * stickSensitivity; //sets the variable pitch, the x axis, to the y value given by the mouse
            pitch = Mathf.Clamp(pitch, pitchMin, pitchMax); //sets the value of the variable between the pitchMin value and the pitchMax value

            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime); //function to smooth the camera

            transform.eulerAngles = currentRotation; //sets the angles of the transform component this script is attached to (the main camera) to the value that I want for angles 

            transform.position = target.position - transform.forward * distanceFromTarget; //sets the position of the object to be target position 
        }
    }
}
