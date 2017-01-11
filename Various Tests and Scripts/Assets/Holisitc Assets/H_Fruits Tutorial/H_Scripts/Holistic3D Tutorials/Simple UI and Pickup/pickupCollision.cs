using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupCollision : MonoBehaviour {

    public GameObject inventoryPanel; //put the panel that will be the used for the inventory
    public GameObject[] inventoryIcons; //array of icons that will be attached at each element

    void OnCollisionEnter(Collision collision)
    {
      //remember transform refers to the transform/position component of an object
       foreach(Transform child in inventoryPanel.transform) // looks at each child in the inventory for an exisiting icon
         {  
            //if the item is in the inventory
            if(child.gameObject.tag == collision.gameObject.tag) //goes through if there is a child in the inventory of the character 
            {
                string c = child.Find("Text").GetComponent<Text>().text; //finds the object named "Text" and gets that text that is contained within it
                int tcount = System.Int32.Parse(c) + 1; //converts the string to an integer to add one
                child.Find("Text").GetComponent<Text>().text = "" + tcount; //displays the number
                return;
            }
         }

        GameObject i; //designates a variable of type GameObject that will be used to create new items
        if(collision.gameObject.tag == "red") //if the tag of the object is equal to red
        {
            i = Instantiate(inventoryIcons[0]);
            i.transform.SetParent(inventoryPanel.transform); //sets the newly created gameobject's transform/position to the Panel's position
        }
        else if(collision.gameObject.tag == "blue")
        {
            i = Instantiate(inventoryIcons[1]);
            i.transform.SetParent(inventoryPanel.transform);
        }
        else if (collision.gameObject.tag == "green")
        {
            i = Instantiate(inventoryIcons[2]);
            i.transform.SetParent(inventoryPanel.transform);
        }
        if(collision.gameObject.tag == "weapon")
        {
            i = Instantiate(inventoryIcons[3]);
            i.transform.SetParent(inventoryPanel.transform);
        }
    }

}
