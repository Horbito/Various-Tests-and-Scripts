using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_Interact : MonoBehaviour {

    public Transform interactObject;

    void FixedUpdate()
    {
        if(Input.GetButton("A_Button"))
        {
            GetInteraction();
        }
    }

    void GetInteraction()
    {
        float distancePlayerAndObject = Vector3.Distance(this.transform.position, interactObject.transform.position);
        if (distancePlayerAndObject < 5.0f && Physics.Raycast(transform.position, Vector3.forward, 10))
        {
            Debug.Log("I am interacting with this");
        }
    }

}
