﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_InputGamepad_Controller : MonoBehaviour {

    //controls the speed of the character
    public float walkSpeed = 2;
    public float runSpeed = 6;

    //controls the smoothness of the rotating/turning the character
    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f; //approximately the amount of time that it will take to reach currentspeed to targetspeed
    float speedSmoothVelocity; //variable that the smoothness function can reference to manipulate
    float currentSpeed; //sets a current speed for a startin point for the smoothness

    public float animationSpeedPercent;

    Animator animator;
    GameObject thePlayer;
    My_InputMapping inputMapping;
    My_SwitchPOV switchManage;
    public Transform cameraTransform;

    // Use this for initialization
    void Start ()
    {
        thePlayer = this.gameObject;
        inputMapping = thePlayer.GetComponent<My_InputMapping>();
        switchManage = thePlayer.GetComponent<My_SwitchPOV>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(switchManage.combatMode == true)
        {
            //allows rotation
            Vector2 input = new Vector2(inputMapping.IM_KeyLeftRight_LeftJoystickX, inputMapping.IM_KeyForwardBackward_LeftJoystickY); //
            Vector2 inputDirection = input.normalized; //

            //this function allows smooth movement and rotation of the object and the function runes if the value of the input is not zero
            if (inputDirection != Vector2.zero)
            {
                //rotation of the game object and the main camera rotation for directing the object direction 
                float targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y; //camera is added so it stays with the player's rotation
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime); //sets rotation and smooths rotation
            }

            bool isRunning = inputMapping.IM_LeftStickClick; //isRunning is set to true when it gets the left shift input
            float targetSpeed = ((isRunning) ? runSpeed : walkSpeed) * inputDirection.magnitude; //question if isRunning true, and if it is, then we go with run speed, if not then walk speed
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime); //smooths movment


            //multiples to forward/blue/Z axis of the transform component by the speed
            transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

            //makes a variable to change the "speedPercent" which changes the animation, if isRunning is true will set speedPercent to 1 which will correspond to the run animation
            animationSpeedPercent = ((isRunning) ? 1 : .5f) * inputDirection.magnitude;
            animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime); //smooths animation
        }
        else if(switchManage.combatMode == false)
        {
            Vector2 inputForward = new Vector2(0, inputMapping.IM_KeyForwardBackward_LeftJoystickY);
            Vector2 inputDirectionForward = inputForward.normalized;
            Vector2 inputStraffe = new Vector2(inputMapping.IM_KeyLeftRight_LeftJoystickX, 0);
            Vector2 inputDirectionStraffe = inputStraffe.normalized;

            bool isRunning = inputMapping.IM_LeftStickClick;
            bool isInputStraffe = (inputDirectionStraffe.magnitude > 0.15);
            float targetSpeedForward = ((isRunning) ? runSpeed : walkSpeed) * inputMapping.IM_KeyForwardBackward_LeftJoystickY;
            float targetSpeedStraffe = ((isRunning) ? runSpeed : walkSpeed) * inputMapping.IM_KeyLeftRight_LeftJoystickX;

            transform.Translate(targetSpeedStraffe * Time.deltaTime, 0, targetSpeedForward * Time.deltaTime);

            float animationSpeedPercent = ((isRunning) ? 1 : 0.5f) * ((isInputStraffe) ? inputDirectionStraffe.magnitude : inputDirectionForward.magnitude);
            animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
        }

    }
}
