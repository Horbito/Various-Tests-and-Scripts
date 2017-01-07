using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectHit : MonoBehaviour {

    public Slider healthbar;
    Animator animator;
    public string opponent;

    void OnTriggerEnter(Collider other) //ontriggerenter references two triggers with one at least a rigidbody that are colliding with each other
    {
        if (other.gameObject.tag != opponent) return; //other references the other collider that is hitting the collider the script is attacted to

        healthbar.value -= 20; //decreases the slider/healthbar by 20 each time the object gets hit
        animator.SetBool("isHit", true);
        Invoke("setBoolBack", 1);

        if (healthbar.value <= 0)
        {
            animator.SetBool("isDead", true);
        }
    }

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
    }

    private void setBoolBack()
    {
        animator.SetBool("isHit", false);
    }
}
