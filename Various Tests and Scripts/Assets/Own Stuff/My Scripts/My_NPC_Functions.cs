using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class My_NPC_Functions : MonoBehaviour {

    //public int[] dialogueLineNumberOption; used originally with options in the dialogue system
    public string[] npcDialogueLines;
    public TextAsset textFile;
    public string npcName;

    void Start()
    {
        if(textFile != null)
        {
            npcDialogueLines = (textFile.text.Split('\n'));
        }
    }

    // example of how to use custom events in the inspector for UnityEvents
    public void saySomething()
    {
        npcName = npcDialogueLines[0];
        My_DialogueSystem.Instance.AddNewDialogue(npcDialogueLines, npcName);
    }
}
