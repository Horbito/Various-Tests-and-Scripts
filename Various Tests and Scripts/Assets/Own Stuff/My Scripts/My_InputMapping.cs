using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_InputMapping : MonoBehaviour {

    public bool IM_ButtonA;
    public bool IM_ButtonY;
    public bool IM_ButtonB;
    public bool IM_ButtonX;

    GameObject playerCharacter;
    My_SwitchPOV switchInput;

	
	void Start ()
    {
        playerCharacter = this.gameObject;
        switchInput = playerCharacter.gameObject.GetComponent<My_SwitchPOV>();
    }

    void Update()
    {
        //Buttons for character animation controller
        IM_ButtonA = ((switchInput.usingKeyboard) ? Input.GetKey(KeyCode.E) : Input.GetButtonDown("A_Button")); //create weapon
        IM_ButtonY = ((switchInput.usingKeyboard) ? Input.GetKey(KeyCode.Alpha2) : Input.GetButtonDown("Y_Button")); //give Take Weapon
        IM_ButtonB = ((switchInput.usingKeyboard) ? Input.GetKey(KeyCode.F) : Input.GetButtonDown("B_Button")); //unseathe
        IM_ButtonX = ((switchInput.usingKeyboard) ? Input.GetMouseButtonDown(0) : Input.GetButton("X_Button")); //attack
    }

}
