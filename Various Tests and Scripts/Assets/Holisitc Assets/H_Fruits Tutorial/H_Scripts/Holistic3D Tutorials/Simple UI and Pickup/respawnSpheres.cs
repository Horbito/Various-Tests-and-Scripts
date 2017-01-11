using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnSpheres : MonoBehaviour {

    void OnCollisionEnter()
    {
       /*
        * OneCollisionEnter() MUST be called if you want to do something when an object is collided with
        * Get the MeshRenderer and the Collider components of the object and turn them off so you do not
        * collide or see the object
        * Invoke allows the fuction Respawn to be called after 5 seconds
        */
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<SphereCollider>().enabled = false;

        Invoke("Respawn", 5);
    }

    void Respawn()
    {
        //enables collision and rendering of the object
        this.GetComponent<MeshRenderer>().enabled = true;
        this.GetComponent<SphereCollider>().enabled = true;
    }


}
