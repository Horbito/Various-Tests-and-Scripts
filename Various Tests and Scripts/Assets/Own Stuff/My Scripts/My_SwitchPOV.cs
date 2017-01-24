using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_SwitchPOV : MonoBehaviour {

    //use this script to switch between POV
    
    public My_InputGamepad_Controller thirdPersonController;
    public My_ThirdPersonCamera thirdPersonCamera;

    //public My_FPS_PlayerController fpsPlayerController;
    //public My_FPS_CameraController fpsCameraController;
    //public SkinnedMeshRenderer bodyRender;
    //public SkinnedMeshRenderer headRender;
    //public Camera fpsMainCamera;
    //public Camera thirdPersonMainCamera;
    //bool fpsActivated = true;

    bool thirdPersonActivated;

    public bool usingKeyboard = false;
    public bool usingGamepad = true;

    void Update ()
    {
      if(usingKeyboard == true) { usingGamepad = false; }
      if(usingGamepad == true){ usingKeyboard = false; }

      if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape)) { Cursor.lockState = CursorLockMode.None; Cursor.visible = true; }
      if (Cursor.lockState == CursorLockMode.None && Input.GetKeyDown(KeyCode.Escape)) { Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false; }

      if(Input.GetKey(KeyCode.Tab) && usingKeyboard == true) { usingKeyboard = false; usingGamepad = true; }
      else if(Input.GetButton("Right_Bumper") && usingGamepad == true) { usingKeyboard = true; usingGamepad = false; }


      /////////////////////////////////////////////////////////////////////////////
                         /// Used for Switching the POV ///
      /////////////////////////////////////////////////////////////////////////////
      /*
      if(usingGamepad == true)
      {
            if (Input.GetButton("Left_Bumper") && fpsActivated)
            {
                thirdPersonMainCamera.transform.localPosition = fpsMainCamera.transform.position;

                fpsPlayerController.enabled = false;
                fpsCameraController.enabled = false;
                fpsMainCamera.enabled = false;

                thirdPersonMainCamera.enabled = true;
                thirdPersonController.enabled = true;
                thirdPersonCamera.enabled = true;
                //bodyRender.enabled = true;
                //headRender.enabled = true;

                fpsActivated = false;
                thirdPersonActivated = true;
            }
            else if (Input.GetButton("Left_Bumper") && thirdPersonActivated)
            {
                thirdPersonMainCamera.transform.localPosition = fpsMainCamera.transform.position;

                fpsPlayerController.enabled = true;
                fpsCameraController.enabled = true;
                fpsMainCamera.enabled = true;

                thirdPersonCamera.enabled = false;
                thirdPersonController.enabled = false;
                thirdPersonCamera.enabled = false;
                //bodyRender.enabled = false;
                //headRender.enabled = false;

                fpsActivated = true;
                thirdPersonActivated = false;
            }
        }
      if(usingKeyboard == true)
      {
            if (Input.GetKeyDown(KeyCode.Tab) && fpsActivated)
            {
                thirdPersonMainCamera.transform.localPosition = fpsMainCamera.transform.position;
                fpsPlayerController.enabled = false;
                fpsCameraController.enabled = false;
                fpsMainCamera.enabled = false;

                thirdPersonMainCamera.enabled = true;
                thirdPersonController.enabled = true;
                thirdPersonCamera.enabled = true;
                //bodyRender.enabled = true;
                //headRender.enabled = true;

                fpsActivated = false;
                thirdPersonActivated = true;
            }
            else if (Input.GetKeyDown(KeyCode.Tab) && thirdPersonActivated)
            {
                thirdPersonMainCamera.transform.localPosition = fpsMainCamera.transform.position;
                fpsPlayerController.enabled = true;
                fpsCameraController.enabled = true;
                fpsMainCamera.enabled = true;

                thirdPersonCamera.enabled = false;
                thirdPersonController.enabled = false;
                thirdPersonCamera.enabled = false;
                //bodyRender.enabled = false;
                //headRender.enabled = false;

                fpsActivated = true;
                thirdPersonActivated = false;
            }
        }
      */
	}
}
