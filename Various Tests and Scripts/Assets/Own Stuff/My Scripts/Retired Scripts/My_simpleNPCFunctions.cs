using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_simpleNPCFunctions : MonoBehaviour {

    public string[] npcDialogue;
    public string npcName;

    // example of how to use custom events in the inspector for UnityEvents
    public void saySomething()
    {
        //My_DialogueSystem.Instance.AddNewDialogue(npcDialogue, npcName);
    }

}
