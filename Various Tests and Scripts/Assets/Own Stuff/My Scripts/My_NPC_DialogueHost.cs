using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class My_NPC_DialogueHost : MonoBehaviour {

    public string npcName;
    public TextAsset dialogueLinesFile;
    public TextAsset dialogueAfterLinesFile;
    //[HideInInspector] //hides the dialogue lines in the inspector
    public string[] npcDialogueLines;
    //[HideInInspector] //hides the npcAfterDialogueLines lines in the inspector
    public string[] npcAfterDialogueLines;
    public int numberToGetAfterDialogue = 0;
    public int alreadyTalked = 5;

    void Update()
    {
        if (dialogueLinesFile != null)
        {
            npcDialogueLines = (dialogueLinesFile.text.Split('\n'));
        }
        if (dialogueAfterLinesFile != null)
        {
            npcAfterDialogueLines = (dialogueAfterLinesFile.text.Split('\n'));
        }

    }

    // example of how to use custom events in the inspector for UnityEvents
    public void saySomething()
    {
        if (numberToGetAfterDialogue <= alreadyTalked)
        {
            My_DialogueSystem.Instance.AddNewDialogue(npcDialogueLines, npcName);
            numberToGetAfterDialogue++;
        }
        else
        {
            My_DialogueSystem.Instance.AddNewDialogue(npcAfterDialogueLines, npcName);
        }
    }
}
