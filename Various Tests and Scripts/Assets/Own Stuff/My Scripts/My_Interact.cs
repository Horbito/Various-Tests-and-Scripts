using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_Interact : MonoBehaviour {

    public My_Interactable interactableObject;
    My_InputMapping inputManage;

    void Start()
    {
        inputManage = this.gameObject.GetComponent<My_InputMapping>();
    }

    void Update()
    {
        My_Interactable interactableHit = null;
        Transform mainCameraTransform = Camera.main.transform;

        Ray ray2 = new Ray(mainCameraTransform.position, mainCameraTransform.TransformDirection(Vector3.forward));
        //Debug.DrawRay(Camera.main.transform.position, Vector3.forward, Color.red);
        Debug.DrawRay(mainCameraTransform.position, mainCameraTransform.TransformDirection(Vector3.forward), Color.red);
        RaycastHit hitInfo;

        //cast a ray from the ray specificed then gets the info from out hitInfo from the object which the ray hit
        //if (Physics.Raycast(mainCameraTransform.position, mainCameraTransform.TransformDirection(Vector3.forward), out hitInfo, 50.0f))
        if(Physics.Raycast(ray2, out hitInfo))
        {
            interactableHit = hitInfo.transform.GetComponent<My_Interactable>(); //gets the component "my_interactable" from the object which the ray hit
            if ((interactableHit != null) && (hitInfo.distance > interactableHit.maxRange)) //runs if the object has the transform component
            {
                interactableHit = null; //sets the interactable hit to null which means it cannot be interacted with
                //Debug.Log("I am hitting something with this ray");
            }
        }

        //creates the highlight effect
        if (interactableHit != interactableObject) //if the interactablehit does not equal the interactableobject
        {
            if (interactableObject != null) //if there is not an interactable Object then that means the ray is off the object so dehighlight
            {
                interactableObject.onDeHighlight.Invoke();
                Debug.Log("I am DeHighlighting this");
            }
            interactableObject = interactableHit; //switches the interactable object with the hit
            if (interactableObject != null) //if the hit does not equal null than that means the ray is on an object so it is highlighted
            {
                interactableObject.onHighlight.Invoke();
                Debug.Log("I am highlighting this");
            }
        }

        if(inputManage.IM_ButtonA && (interactableObject != null))
        {
            interactableObject.onSelect.Invoke();
            Debug.Log(" I am interacting with this");
        }
       
    }
}
