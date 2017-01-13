using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_CharAnimation_Controller : MonoBehaviour {

    public GameObject[] weapons;
    public Transform weaponPosition;

    //booleans to help control the animations
    public bool Y_Down = false;
    public bool X_Down = false;
    public bool B_Down = false;
    public bool A_Down = false;

    GameObject weapon;
    Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        //creates a weapon, in this case the sword, based of what is put in element zero
        //sets the weapon's parent to the variable transform weaponPosition's transform which is an empty child of the sword/weapon bone
        //sets the position and rotation to the empty child so it is in the right orientation
        if (Input.GetButtonDown("A_Button") && !A_Down)
        {
            weapon = Instantiate(weapons[0]);
            weapon.transform.SetParent(weaponPosition);
            weapon.transform.localPosition = weaponPosition.transform.localPosition + new Vector3(0, 0.002f); //added 0.002f to the y axis because of the model i made
            weapon.transform.localRotation = weaponPosition.transform.localRotation;
            A_Down = true;
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
        else { animator.SetBool("isAttacking", false); }

    }
}
