using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class My_DialogueSystem : MonoBehaviour {
    public static My_DialogueSystem Instance { get; set; }
    public GameObject dialoguePanel;
    public string npcName;
    public List<string> dialogueLines = new List<string>(); //creates a new list of type string 

    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;

	void Awake () {
        continueButton = dialoguePanel.transform.FindChild("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.FindChild("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.FindChild("Name").FindChild("Text").GetComponent<Text>();
        dialoguePanel.SetActive(false);

		if(Instance != null && Instance != this) //runs if there is an existing dialouge system and it is not this "one"
        {
            Destroy(gameObject); //if the statement is true, it destroys the instance of the object so it does not conflict
        }
        else
        {
            Instance = this; //if there is not an exisiting instance, set it to this one
        }
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            ContinueDialogue();
        }
    }


    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0; //sets the index to 0 because the first element of an index is 0
        dialogueLines = new List<string>(lines.Length); //assigns the dialogue lines to a list of strings comprised of the length/number of lines
        dialogueLines.AddRange(lines); //adds the dialogue
        this.npcName = npcName; //sets this instance's name to the npcName we give it
        Debug.Log(dialogueLines.Count); // counts the number of lines we have
        CreateDialogue(); //creates the initial dialogue
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex]; //displays whichever numbered index the dialouge index is set to which is 0
        nameText.text = npcName; //sets the text of the NPC to the npcName we give it
        dialoguePanel.SetActive(true); //turns on the dialogue panel
        Cursor.lockState = CursorLockMode.None; // makes sure the curosor is not restrained
        Cursor.visible = true; //makes sure the cursor is visible
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1) //if there is still more dialogue lines than we have in the index
        {
            dialogueIndex++; //increases the index to the next number
            dialogueText.text = dialogueLines[dialogueIndex]; //sets the next dialogue to the next index
        }
        else //if there are no more lines
        {
            dialoguePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
