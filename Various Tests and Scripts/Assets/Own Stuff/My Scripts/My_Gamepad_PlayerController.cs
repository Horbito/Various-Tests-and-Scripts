using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_Gamepad_PlayerController : MonoBehaviour
{
    //controls the speed of the character
    public float walkSpeed = 2;
    public float runSpeed = 6;

    //controls the smoothness of the rotating/turning the character
    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f; //approximately the amount of time that it will take to reach currentspeed to targetspeed
    float speedSmoothVelocity; //variable that the smoothness function can reference to manipulate
    float currentSpeed; //sets a current speed for a startin point for the smoothness

    //
    public GameObject[] weapons;
    public Transform weaponPosition;

    //booleans to help control the animations
    public bool Y_Down = false;
    public bool X_Down = false;
    public bool B_Down = false;
    public bool A_Down = false;

    GameObject i;
    Animator animator;
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
        //creates a weapon, in this case the sword, based of what is put in element zero
        //sets the weapon's parent to the variable transform weaponPosition's transform which is an empty child of the sword/weapon bone
        //sets the position and rotation to the empty child so it is in the right orientation
        if (Input.GetButtonDown("A_Button") && !A_Down)
        {
            i = Instantiate(weapons[0]);
            i.transform.SetParent(weaponPosition);
            i.transform.localPosition = weaponPosition.transform.localPosition + new Vector3(0, 0.002f);
            i.transform.localRotation = weaponPosition.transform.localRotation;
        }

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
    //Old animation method to shorten code above, but it doesn't work
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
    


