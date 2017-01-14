using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_FPS_CameraController : MonoBehaviour {

    Vector2 joystickLook;
    Vector2 smoothVelocity;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject playerCharacter;

	void Start ()
    {
        playerCharacter = this.transform.parent.gameObject;	
	}
	
	void Update ()
    {
        Vector2 joystickDelta = new Vector2(Input.GetAxisRaw("Right_Horizontal_Joystick"), -(Input.GetAxisRaw("Right_Vertical_Joystick")));

        //multiples/scales the joystick delta by the sentivity and smoothing
        joystickDelta = Vector2.Scale(joystickDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothVelocity.x = Mathf.Lerp(smoothVelocity.x, joystickDelta.x, 1.0f / smoothing); //smooths camera between the current value and the new delta value read in the x direction
        smoothVelocity.y = Mathf.Lerp(smoothVelocity.y, joystickDelta.y, 1.0f / smoothing); //smooths camera between the current value and the new delta value read in the y direction
        joystickLook += smoothVelocity;
        joystickLook.y = Mathf.Clamp(joystickLook.y, -90.0f, 90.0f); // clamps the y value rotation to -90 and 90


        transform.localRotation = Quaternion.AngleAxis(-joystickLook.y, Vector3.right);
        playerCharacter.transform.localRotation = Quaternion.AngleAxis(joystickLook.x, playerCharacter.transform.up);
	}
}
