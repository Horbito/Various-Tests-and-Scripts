using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_Interact : MonoBehaviour {

    public Transform interactObject;

    void Update()
    {
        Vector3 directionVector = this.transform.position - interactObject.transform.position;
        float viewAngle = Vector3.Angle(directionVector, this.transform.forward);
        if (Input.GetButton("A_Button") && viewAngle < 30)
        {
            GetInteraction();
        }

    }

    void GetInteraction()
    {
        float distancePlayerAndObject = Vector3.Distance(this.transform.position, interactObject.transform.position);
        if (distancePlayerAndObject < 5.0f)
        {
            Debug.Log("I am interacting with this");
        }
    }

}
