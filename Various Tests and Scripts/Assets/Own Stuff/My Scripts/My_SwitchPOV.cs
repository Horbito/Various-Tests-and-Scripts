using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_SwitchPOV : MonoBehaviour {

    public My_FPS_PlayerController fpsPlayerController;
    public My_FPS_CameraController fpsCameraController;
    public My_InputGamepad_Controller thirdPersonController;
    public My_ThirdPersonCamera thirdPersonCamera;
    public SkinnedMeshRenderer bodyRender;
    public SkinnedMeshRenderer headRender;
    public Camera fpsMainCamera;
    public Camera thirdPersonMainCamera;

    bool fpsActivated = true;
    bool thirdPersonActivated;

	void Update ()
    {
	    if(Input.GetButton("Left_Bumper") && fpsActivated)
        {
            fpsPlayerController.enabled = false;
            fpsCameraController.enabled = false;
            fpsMainCamera.enabled = false;

            thirdPersonMainCamera.enabled = true;
            thirdPersonController.enabled = true;
            thirdPersonCamera.enabled = true;
            bodyRender.enabled = true;
            headRender.enabled = true;

            fpsActivated = false;
            thirdPersonActivated = true;
        }
        else if(Input.GetButton("Left_Bumper") && thirdPersonActivated)
        {
            fpsPlayerController.enabled = true;
            fpsCameraController.enabled = true;
            fpsMainCamera.enabled = true;

            thirdPersonCamera.enabled = false;
            thirdPersonController.enabled = false;
            thirdPersonCamera.enabled = false;
            bodyRender.enabled = false;
            headRender.enabled = false;

            fpsActivated = true;
            thirdPersonActivated = false;
        }
	}
}
