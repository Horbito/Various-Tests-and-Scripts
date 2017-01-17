using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_InputMapping : MonoBehaviour {

    public bool createWeapon;
    public bool giveTakeWeapon;
    public bool unseathe;
    public bool attack;

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
        createWeapon = ((switchInput.usingKeyboard) ? Input.GetKey(KeyCode.E) : Input.GetButtonDown("A_Button"));
        giveTakeWeapon = ((switchInput.usingKeyboard) ? Input.GetKey(KeyCode.Alpha2) : Input.GetButtonDown("Y_Button"));
        unseathe = ((switchInput.usingKeyboard) ? Input.GetKey(KeyCode.F) : Input.GetButtonDown("B_Button"));
        attack = ((switchInput.usingKeyboard) ? Input.GetMouseButtonDown(0) : Input.GetButton("X_Button"));
    }

}
