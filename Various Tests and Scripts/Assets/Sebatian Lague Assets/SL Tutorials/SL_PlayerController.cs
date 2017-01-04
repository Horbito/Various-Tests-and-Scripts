using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SL_PlayerController : MonoBehaviour {

    public float walkSpeed = 2;
    public float runSpeed = 6;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    Animator animator;
    Transform cameraTransform;

	void Start () {
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
	}
	
	void Update () {

        //allows rotation
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //
        Vector2 inputDirection = input.normalized; //

        //this function allows smooth movement and rotation of the object and the function runes if the value of the input is not zero
        if (inputDirection != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime); //sets rotation and smooths rotation
        }

        bool isRunning = Input.GetKey(KeyCode.LeftShift); //isRunning is set to true when it gets the left shift input
        float targetSpeed = ((isRunning) ? runSpeed : walkSpeed) * inputDirection.magnitude; //question if isRunning true, and if it is, then we go with run speed, if not then walk speed
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime); //smooths movment

        //multiples to forward/blue/Z axis of the transform component by the speed
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        float animationSpeedPercent = ((isRunning) ? 1 : .5f) * inputDirection.magnitude; //makes a variable to change the "speedPercent" which changes the animation
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime); //smooths animation
	}
}
