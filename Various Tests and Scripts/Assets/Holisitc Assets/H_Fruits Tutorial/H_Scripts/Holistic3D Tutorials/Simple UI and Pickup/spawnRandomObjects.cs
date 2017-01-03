using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRandomObjects : MonoBehaviour {

    /*
     * This script allows gameobjects/prefabs to be spawned on various different game objects, such as fruits on plants
     */

    public GameObject prefab; //shows in the inspector to put a prefab that will randomly spawned
    public int spawnNumber; //shows in the inspector the amount of the gameobject wanted to be spawned
    //float[] limitRange = new float[] { -1.0f, 1.0f, -1.0f, 1.0f, -1.0f, 1.0f }; //( {X min, X max, Y min, Y max, Z min, Z max}
    public float[] limitRange;


    void spawn()
    {
        for(int i = 0; i < spawnNumber; i++)
        {
          /*
           * takes "this" item, the item that the gameobject will randomly spawn on, and give the prefab/gameobject
           * a position based on the center position of the "this" and then adding a random number to displace it from
           * the center of "this" item
           */
            Vector3 itemPos = new Vector3(this.transform.position.x + Random.Range(limitRange[0], limitRange[1]),
                                          this.transform.position.x + Random.Range(limitRange[2], limitRange[3]),
                                          this.transform.position.x + Random.Range(limitRange[4], limitRange[5]));
            Instantiate(prefab, itemPos, Quaternion.identity);
        }
    }

	// Use this for initialization
	void Start ()
    {
        spawn();
	}
	

}
