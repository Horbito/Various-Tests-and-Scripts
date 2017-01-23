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

    GameObject playerCharacter;
    GameObject weapon;
    Animator animator;
    My_SwitchPOV switchInput;
    My_InputMapping inputManage;

    // Use this for initialization
    void Start ()
    {
        playerCharacter = this.gameObject;
        switchInput = playerCharacter.GetComponent<My_SwitchPOV>();
        inputManage = playerCharacter.GetComponent<My_InputMapping>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {   
        //creates a weapon, in this case the sword, based of what is put in element zero
        //sets the weapon's parent to the variable transform weaponPosition's transform which is an empty child of the sword/weapon bone
        //sets the position and rotation to the empty child so it is in the right orientation
        if (inputManage.IM_ButtonA && !A_Down)
        {
            weapon = Instantiate(weapons[0]);
            weapon.transform.SetParent(weaponPosition);
            weapon.transform.localPosition = weaponPosition.transform.localPosition + new Vector3(0, 0.002f); //added 0.002f to the y axis because of the model i made
            weapon.transform.localRotation = weaponPosition.transform.localRotation;
            A_Down = true; //makes sure that a weapon can not be made multiple times because one of the requirements of this if statement is false
        }

        //animationFunction("Y_Button", Y_Down, "hasSword");
        //animations, works ONLY if it is an FBX; REMEMBER TO ALWAYS IMPORT AS AN FBX
        
        //transitions from no sword to with sword animations
        if (inputManage.IM_ButtonY && !Y_Down)
        {
            animator.SetBool("hasSword", true);
            Y_Down = true;
        }
        else if (inputManage.IM_ButtonY && Y_Down && weaponPosition.childCount <= 0)
        {
            animator.SetBool("hasSword", false);
            Y_Down = false;
        }
        else if (inputManage.IM_ButtonY && weaponPosition.childCount > 0)
        {
            //cannot go back since the player has a sword
        }

        //transitions from sword animation to unseathing animation
        if (inputManage.IM_ButtonB && !B_Down)
        {
            animator.SetBool("hasSwordOut", true);
            B_Down = true;
        }
        else if (inputManage.IM_ButtonB && B_Down)
        {
            animator.SetBool("hasSwordOut", false);
            B_Down = false;
        }

        //trainsitions from unseathing animation to attacking animation
        if (inputManage.IM_ButtonX) { animator.SetBool("isAttacking", true); }
        else { animator.SetBool("isAttacking", false); }

    }
}
