using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_Gamepad_PlayerController : MonoBehaviour
{
    public float walkSpeed = 2;
    public float runSpeed = 6;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    bool Y_Down = false;
    bool X_Down = false;
    bool B_Down = false;

    Animator animator;
    //public SkinnedMeshRenderer sword;
    Transform cameraTransform;


    void Start()
    {
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
        //sword = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    void Update()
    {

        //allows rotation
        Vector2 input = new Vector2(Input.GetAxisRaw("Left_Horizontal_Joystick"), -(Input.GetAxisRaw("Left_Vertical_Joystick"))); //
        Vector2 inputDirection = input.normalized; //

        //this function allows smooth movement and rotation of the object and the function runes if the value of the input is not zero
        if (inputDirection != Vector2.zero)
        {
            //rotation of the game object and the main camera rotation for directing the object direction 
            float targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime); //sets rotation and smooths rotation
        }

        bool isRunning = Input.GetButton("Left_Click_Joystick"); //isRunning is set to true when it gets the left shift input
        float targetSpeed = ((isRunning) ? runSpeed : walkSpeed) * inputDirection.magnitude; //question if isRunning true, and if it is, then we go with run speed, if not then walk speed
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime); //smooths movment

        //multiples to forward/blue/Z axis of the transform component by the speed
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);



        //makes a variable to change the "speedPercent" which changes the animation, if isRunning is true will set speedPercent to 1 which will correspond to the run animation
        float animationSpeedPercent = ((isRunning) ? 1 : .5f) * inputDirection.magnitude;
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime); //smooths animation

    }

    void LateUpdate()
    {
        //animationFunction("Y_Button", Y_Down, "hasSword");
        //animations, works ONLY if it is an FBX; REMEMBER TO ALWAYS IMPORT AS AN FBX
        //transitions from no sword to with sword animations

        if (Input.GetButtonDown("Y_Button") && !Y_Down)
        {
            animator.SetBool("hasSword", true);
            Y_Down = true;
        }
        else if (Input.GetButtonDown("Y_Button"))
        {
            animator.SetBool("hasSword", false);
            Y_Down = false;
        }

        //transitions from sword animation to unseathing animation
        if (Input.GetButtonDown("B_Button") && !B_Down)
        {
            animator.SetBool("hasSwordOut", true);
            B_Down = true;
        }
        else if (Input.GetButtonDown("B_Button") && B_Down)
        {
            animator.SetBool("hasSwordOut", false);
            B_Down = false;
        }

        //trainsitions from unseathing animation to attacking animation
        if (Input.GetButtonDown("X_Button")) { animator.SetBool("isAttacking", true); }
        else{ animator.SetBool("isAttacking", false); }

    }
}
    //won't work for some damn reason even though it is the exact same as above
    /*
    void animationFunction(string buttonName, bool buttonDown, string boolAnimationName) //(X_Button, X_Down, "isAttacking") example 
    {
        if(Input.GetButtonDown(buttonName) && (buttonDown == false))
        {
            animator.SetBool(boolAnimationName, true);
            buttonDown = true;
        }
        else if(Input.GetButtonDown(buttonName) && (buttonDown == true))
        {
            print("this part works");
            animator.SetBool(boolAnimationName, false);
            buttonDown = false;
        }
    }
    */
    


