using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_NPC_DialogueHost : MonoBehaviour {

    public int[] dialogueOpenOptions = new int[4] { 0, 0, 0, 0 }; //used originally with options in the dialogue system, used with EXACT line numbering
    public string[] npcDialogueLines;
    public TextAsset textFile;
    public string npcName;

    public int endLineEarly = 0;
    public int[] dialogueOptionStartLine = new int[4] { 0, 0, 0, 0 };

    void Start()
    {
        for (int i = 0; i < dialogueOpenOptions.Length; i++)
        {
            dialogueOpenOptions[i] = dialogueOpenOptions[i] - 1;
        }

        for (int i = 0; i < dialogueOptionStartLine.Length; i++)
        {
            dialogueOptionStartLine[i] = dialogueOptionStartLine[i] - 2;
        }
    }

    void Update()
    {

        if (textFile != null)
        {
            npcDialogueLines = (textFile.text.Split('\n'));
        }

    }

    // example of how to use custom events in the inspector for UnityEvents
    public void saySomething()
    {
        My_DialogueSystem.Instance.AddNewDialogue(npcDialogueLines, npcName);
    }
}
