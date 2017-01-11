using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slPlayer : MonoBehaviour
{

    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); //(Y axis, X axis, Z axis) movment
        Vector3 direction = input.normalized; // normalize the input so the player does not move more diagonally
        Vector3 velocity = speed * direction;
        Vector3 moveAmount = velocity * Time.deltaTime;

        //transform.position += moveAmount; Alternative Option
        transform.Translate(moveAmount); //Most Common Option
    }
}
