using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_LineOfSightChase : MonoBehaviour {

    public Transform player;
    public float speed = 0.1f;
    static Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>(); //sets the animator variable to the animator component
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = player.position - this.transform.position; //calculates the vector between the position of the player and the object
        float angle = Vector3.Angle(direction, this.transform.forward); //gets the angle of the vector and the blue/Z axis

        //runs if the distance between the player and the object this is attached to is less than 10 and the angle is less than 30
        if (Vector3.Distance(player.position, this.transform.position) < 10 && angle < 30)
        {
            direction.y = 0; //so the item does not rotate upwards

            //sets the rotation using the Vector3 direction and using the Slerp to smooth the rotation rather than snap
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false); //sets the idle animation to false since it is within a distance of 10
            if (direction.magnitude > 5) //runs if the length of the vector/distance between the player and is greater than 5
            {
                //moves the object 0.5 in the Z axis direction as along as the magnitude/length of the Vector3 distance is above 5
                this.transform.Translate(0, 0, speed * Time.deltaTime); //make sure the movement in the z axis is not too fast as translate overloads it
                anim.SetBool("isWalking", true);//sets the walking animation true while it is above 5
                anim.SetBool("isAttacking", false);//and the attacking animation to false so it doesn't switch to the attacking animation
            }
            else
            {
                //since the object and the player's distance is less than 5, the object starts attacking
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            //since the distance between both objects is more than 10, the object is idle
            anim.SetBool("isIdle", true);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", false);
        }

    }
}
