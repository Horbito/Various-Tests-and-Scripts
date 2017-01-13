using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_SetScale : MonoBehaviour {
    public float[] scalingVector3 = new float[] { .01f, .01f, .01f };

    void Start()
    {
        //had to do this, specifically to the sword, because the object was l
        this.transform.localScale = new Vector3(scalingVector3[0], scalingVector3[1], scalingVector3[2]);
    }

}
