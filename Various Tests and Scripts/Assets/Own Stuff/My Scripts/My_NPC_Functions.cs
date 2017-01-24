using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class My_NPC_Functions : MonoBehaviour {
    public string[] npcDialogue;
    public string npcName;

    // example of how to use custom events in the inspector for UnityEvents
    public void saySomething()
    {
        My_DialogueSystem.Instance.AddNewDialogue(npcDialogue, npcName);
    }

}
