using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_NPC_DialogueHost : MonoBehaviour {

    public string npcName;
    public TextAsset dialogueLinesFile;
    public TextAsset dialogueAfterLinesFile;
    //[HideInInspector] //hides the dialogue lines in the inspector
    public string[] npcDialogueLines;
    public string[] npcAfterDialogueLines;
    public int[] dialogueOpenOptions; //used originally with options in the dialogue system, used with EXACT line numbering

    public int endLineEarly = 100;
    public int[] dialogueOptionStartLine;
    bool adjustedLineNumbers;
    bool alreadyTalked;

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
        if(adjustedLineNumbers == false)
        {
            //endLineEarly = endLineEarly - 1;
            for (int i = 0; i < dialogueOpenOptions.Length; i++)
            {
                dialogueOpenOptions[i] = dialogueOpenOptions[i] - 1;
            }

            for (int i = 0; i < dialogueOptionStartLine.Length; i++)
            {
                dialogueOptionStartLine[i] = dialogueOptionStartLine[i] - 2;
            }
            adjustedLineNumbers = true;
        }
        else if(adjustedLineNumbers == true) { }

        if(alreadyTalked == false)
        {
            My_DialogueSystem.Instance.AddNewDialogue(npcDialogueLines, npcName);
            alreadyTalked = true;
        }
        else if(alreadyTalked == true)
        {
            My_DialogueSystem.Instance.AddNewDialogue(npcAfterDialogueLines, npcName);
        }
    }
}
