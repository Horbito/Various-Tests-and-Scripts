using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamepad_Controller : MonoBehaviour {

    public float speed = 10;


	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {   
        //basic movement directions with the left joystick
        Vector3 left_input = new Vector3(Input.GetAxisRaw("Left_Horizontal_Joystick"), 0, -(Input.GetAxisRaw("Left_Vertical_Joystick"))); //(Y axis, X axis, Z axis) movment
        Vector3 left_direction = left_input.normalized; // normalize the input so the player does not move more when going diagonally
        Vector3 left_velocity = speed * left_direction;
        Vector3 left_moveAmount = left_velocity * Time.deltaTime;
        transform.Translate(left_moveAmount);

        //up and down direction with the right joystick
        Vector3 right_input = new Vector3(0, (Input.GetAxisRaw("Right_Vertical_Joystick")), 0);
        transform.Translate(right_input);


    }
}
