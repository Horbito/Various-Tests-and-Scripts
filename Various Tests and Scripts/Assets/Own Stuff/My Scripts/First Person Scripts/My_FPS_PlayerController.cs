using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_FPS_PlayerController : MonoBehaviour {

    public float walkSpeed = 2.0f;
    public float runSpeed = 6.0f;
    public float speedSmoothTime = 0.1f; //approximately the amount of time that it will take to reach currentspeed to targetspeed

    Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        //Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 inputForward = new Vector2(0, -(Input.GetAxisRaw("Left_Vertical_Joystick")));
        Vector2 inputDirectionForward = inputForward.normalized;
        Vector2 inputStraffe = new Vector2(Input.GetAxisRaw("Left_Horizontal_Joystick"), 0);
        Vector2 inputDirectionStraffe = inputStraffe.normalized;
        //float translation = -(Input.GetAxisRaw("Left_Vertical_Joystick"));
        //float straffe = Input.GetAxisRaw("Left_Horizontal_Joystick");

        bool isRunning = Input.GetButton("Left_Click_Joystick");
        bool isInputStraffe = (inputDirectionStraffe.magnitude > 0.15);
        float targetSpeedForward = ((isRunning) ? runSpeed : walkSpeed) * -(Input.GetAxisRaw("Left_Vertical_Joystick"));
        float targetSpeedStraffe = ((isRunning) ? runSpeed : walkSpeed) * Input.GetAxisRaw("Left_Horizontal_Joystick");

        transform.Translate(targetSpeedStraffe  * Time.deltaTime, 0, targetSpeedForward * Time.deltaTime);

        float animationSpeedPercent = ((isRunning) ? 1 : 0.5f) * ((isInputStraffe) ? inputDirectionStraffe.magnitude : inputDirectionForward.magnitude);
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
	}
}
