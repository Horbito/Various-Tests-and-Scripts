using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_Interact : MonoBehaviour {

    public My_Interactable interactableObject;
    My_SwitchPOV switchInput;
    My_InputMapping inputManage;

    void Start()
    {
        switchInput = this.gameObject.GetComponent<My_SwitchPOV>();
        inputManage = this.gameObject.GetComponent<My_InputMapping>();
    }

    void Update()
    {
        My_Interactable interactableHit = null;

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one / 2); //Z coordinate is ignored, bottom left is (0,0) and top-right is (1,1)
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)) //cast a ray from the ray specificed then gets the info from out hitInfo from the object which the ray hit
        {
            interactableHit = hitInfo.transform.GetComponent<My_Interactable>(); //gets the component "my_interactable" from the object which the ray hit
            if (interactableHit != null) //runs if the object has the transform component
            {
                if (hitInfo.distance > interactableObject.maxRange) //runs if origin of the ray from where it is project to is greater than the distance permited
                {
                    interactableHit = null; //sets the interactable hit to null which means it cannot be interacted with
                }
            }
        }

        //creates the highlight effect
        if (interactableHit != interactableObject) //if the interactablehit does not equal the interactableobject
        {
            if (interactableObject != null) //if there is not an interactable Object then that means the ray is off the object so dehighlight
            {
                interactableObject.onDeHighlight.Invoke();
            }
            interactableObject = interactableHit; //switches the interactable object with the hit
            if (interactableObject != null) //if the hit does not equal null than that means the ray is on an object so it is highlighted
            {
                interactableObject.onHighlight.Invoke();
            }
        }

        if (switchInput.usingGamepad == true)
        {
            if(inputManage.IM_ButtonA && (interactableObject != null))
            {
                interactableObject.onSelect.Invoke();
            }
        }
    }
}
