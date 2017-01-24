using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_FPS_PlayerController : MonoBehaviour {

    public float walkSpeed = 2.0f;
    public float runSpeed = 6.0f;
    public float speedSmoothTime = 0.1f; //approximately the amount of time that it will take to reach currentspeed to targetspeed

    GameObject thePlayer;
    My_SwitchPOV switchInput;
    Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        thePlayer = this.gameObject;
        switchInput = thePlayer.GetComponent<My_SwitchPOV>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(switchInput.usingGamepad == true)
        {
            Vector2 inputForward = new Vector2(0, -(Input.GetAxisRaw("Left_Vertical_Joystick")));
            Vector2 inputDirectionForward = inputForward.normalized;
            Vector2 inputStraffe = new Vector2(Input.GetAxisRaw("Left_Horizontal_Joystick"), 0);
            Vector2 inputDirectionStraffe = inputStraffe.normalized;

            bool isRunning = Input.GetButton("Left_Click_Joystick");
            bool isInputStraffe = (inputDirectionStraffe.magnitude > 0.15);
            float targetSpeedForward = ((isRunning) ? runSpeed : walkSpeed) * -(Input.GetAxisRaw("Left_Vertical_Joystick"));
            float targetSpeedStraffe = ((isRunning) ? runSpeed : walkSpeed) * Input.GetAxisRaw("Left_Horizontal_Joystick");

            transform.Translate(targetSpeedStraffe * Time.deltaTime, 0, targetSpeedForward * Time.deltaTime);

            float animationSpeedPercent = ((isRunning) ? 1 : 0.5f) * ((isInputStraffe) ? inputDirectionStraffe.magnitude : inputDirectionForward.magnitude);
            animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
        }

        if(switchInput.usingKeyboard == true)
        {
            Vector2 inputForward = new Vector2(0, Input.GetAxisRaw("Vertical"));
            Vector2 inputDirectionForward = inputForward.normalized;
            Vector2 inputStraffe = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            Vector2 inputDirectionStraffe = inputStraffe.normalized;

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            bool isInputStraffe = (inputDirectionStraffe.magnitude > 0.15);
            float targetSpeedForward = ((isRunning) ? runSpeed : walkSpeed) * Input.GetAxisRaw("Vertical");
            float targetSpeedStraffe = ((isRunning) ? runSpeed : walkSpeed) * Input.GetAxisRaw("Horizontal");

            transform.Translate(targetSpeedStraffe * Time.deltaTime, 0, targetSpeedForward * Time.deltaTime);

            float animationSpeedPercent = ((isRunning) ? 1 : 0.5f) * ((isInputStraffe) ? inputDirectionStraffe.magnitude : inputDirectionForward.magnitude);
            animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
        }

	}
}
