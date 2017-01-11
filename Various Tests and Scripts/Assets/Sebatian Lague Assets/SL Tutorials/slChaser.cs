using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slChaser : MonoBehaviour {

    public Transform targetTransform;

    public float speed = 7;
	
	// Update is called once per frame
	void Update () {
        Vector3 displacmentFromTarget = targetTransform.position - transform.position;
        Vector3 directionToTarget = displacmentFromTarget.normalized;
        Vector3 velocity = directionToTarget * speed;

        float distanceToTarget = displacmentFromTarget.magnitude; //gets the magnitude of the vector

        if (distanceToTarget > 1.5f) // sets a set limit distance of the player and object that is following
        {
            transform.Translate(velocity * Time.deltaTime);
        }
	}
}
