using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class My_NPC_Functions : MonoBehaviour {

    public UnityEvent npcEvents;

    // example of how to use custom events in the inspector for UnityEvents
    public void saySomething(string dialouge)
    {
        //GUI.Label(new Rect())
        print(dialouge);
        npcEvents.Invoke();    
    }

}
