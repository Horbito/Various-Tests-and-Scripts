using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_InputMapping : MonoBehaviour {

    public bool IM_ButtonA;
    public bool IM_ButtonY;
    public bool IM_ButtonB;
    public bool IM_ButtonX;

    public bool IM_LeftStickClick;
    public bool IM_RightStickClick;

    public float IM_KeyForwardBackward_LeftJoystickY;
    public float IM_KeyLeftRight_LeftJoystickX;
    public float IM_MouseVer_RightJoystickY;
    public float IM_MouseHor_RightJoystickX;

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

        IM_LeftStickClick = ((switchInput.usingKeyboard) ? Input.GetKey(KeyCode.LeftShift) : Input.GetButton("Left_Click_Joystick"));

        IM_KeyForwardBackward_LeftJoystickY = ((switchInput.usingKeyboard) ? Input.GetAxisRaw("Vertical") : -(Input.GetAxisRaw("Left_Vertical_Joystick")));
        IM_KeyLeftRight_LeftJoystickX = ((switchInput.usingKeyboard) ? Input.GetAxisRaw("Horizontal") : Input.GetAxisRaw("Left_Horizontal_Joystick"));
        IM_MouseVer_RightJoystickY = ((switchInput.usingKeyboard) ? Input.GetAxisRaw("Mouse Y") : Input.GetAxisRaw("Right_Vertical_Joystick"));
        IM_MouseHor_RightJoystickX = ((switchInput.usingKeyboard) ? Input.GetAxisRaw("Mouse X") : Input.GetAxisRaw("Right_Horizontal_Joystick"));
    }

}
