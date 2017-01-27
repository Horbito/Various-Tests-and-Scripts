using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class My_DialogueSystem_NoOptions : MonoBehaviour {

    /*
    public static My_DialogueSystem Instance { get; set; } //change this back to My_DialogueSystem if used
    public GameObject dialoguePanel;
    public string npcName;
    public List<string> dialogueLines = new List<string>(); //creates a new list of type string 

    int dialogueIndex;

    Button continueButton, exitButton;
    Text dialogueText, nameText;
    GameObject myEventSystem, exitButtonGameObject, continueButtonGameObject;

    Animator playerAnimator;
    My_InputMapping inputMange;
    My_Interact interactMange;
    My_InputGamepad_Controller playerInputs;
    My_NPC_Functions npcFunctions;

    void Awake()
    {
        inputMange = GameObject.Find("Player").GetComponent<My_InputMapping>();
        interactMange = GameObject.Find("Player").GetComponent<My_Interact>();
        playerInputs = GameObject.Find("Player").transform.GetComponent<My_InputGamepad_Controller>();
        playerAnimator = GameObject.Find("Player").transform.GetComponent<Animator>();

        myEventSystem = GameObject.Find("EventSystem");
        continueButtonGameObject = GameObject.Find("Continue");  //gameobject, not the component; used to continue the dialogue
        exitButtonGameObject = GameObject.Find("Exit"); //gameobject, not the component; used to stop the dialogue

        //all children of the dialogue panel set in the inspector
        continueButton = dialoguePanel.transform.FindChild("Continue").GetComponent<Button>(); //gets the button component of the gameobject "Continue"
        exitButton = dialoguePanel.transform.FindChild("Exit").GetComponent<Button>(); //gets the button component of the gameobject "Exit"
        dialogueText = dialoguePanel.transform.FindChild("Text").GetComponent<Text>(); // gets the text compoonent of the gameobject "Text"
        nameText = dialoguePanel.transform.FindChild("Name").FindChild("Text").GetComponent<Text>(); //gets the text component of the gameobject "Name"

        dialoguePanel.SetActive(false); //intially sets the dialogue panel and all its children to false

        if (Instance != null && Instance != this) //runs if there is an existing dialouge system and it is not this "one"
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
        npcFunctions = interactMange.hitInfo.transform.GetComponent<My_NPC_Functions>(); //needs to consitinely check to which NPC Function component it needs to be set to

        //if the currentselected object is the continue button gameobject
        if (myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject == continueButtonGameObject)
        {
            if (inputMange.IM_ButtonA) { ContinueDialogue(); } //if the A button is pressed, activates the continue dialogue function
        }
        else if (myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject == exitButtonGameObject)
        {
            if (inputMange.IM_ButtonA) { BreakDialogue(); } //if the A button is pressed, actiavtes the break dialogue function
        }
    }


    public void AddNewDialogue(string[] lines, string npcName)
    {
        playerInputs.enabled = false;
        dialogueIndex = 0; //sets the index to 0 because the first element of an index is 0
        dialogueLines = new List<string>(lines.Length); //assigns the dialogue lines to a list of strings comprised of the length/number of lines
        dialogueLines.AddRange(lines); //adds the dialogue
        this.npcName = npcName; //sets this instance's name to the npcName we give it
        //Debug.Log(dialogueLines.Count); // counts the number of lines we have
        CreateDialogue(); //creates the initial dialogue
    }

    public void CreateDialogue()
    {
        playerAnimator.SetFloat("speedPercent", 0.0f);
        playerInputs.enabled = false;
        interactMange.enabled = false; //interaction raycasts were interferring with the dialogue, set interactions back to true once dialogue is done
        continueButtonGameObject.SetActive(true);
        exitButtonGameObject.SetActive(true);

        dialogueText.text = dialogueLines[dialogueIndex]; //displays whichever numbered index the dialouge index is set to which is 0
        nameText.text = npcName; //sets the text of the NPC to the npcName we give it
        dialoguePanel.SetActive(true); //turns on the dialogue panel

        //sets the event system selected game object to the continue button first
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("Continue"));

        Cursor.lockState = CursorLockMode.None; // makes sure the curosor is not restrained
        Cursor.visible = true; //makes sure the cursor is visible
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1) //if there is still more dialogue lines than we have in the index
        {
            playerAnimator.SetFloat("speedPercent", 0.0f);
            playerInputs.enabled = false;
            interactMange.enabled = false; //have to disable interactions when in a dialogue so it does not interfere with the continue button
            dialogueIndex++; //increases the index to the next number
            dialogueText.text = dialogueLines[dialogueIndex]; //sets the next dialogue to the next index
        }
        else //if there are no more lines
        {
            playerInputs.enabled = true;
            interactMange.enabled = true; //interaction raycasts were interferring with the dialogue, set interactions back to true once dialogue is done
            dialoguePanel.SetActive(false);
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void BreakDialogue()
    {
        playerInputs.enabled = true;
        interactMange.enabled = true; //interaction raycasts were interferring with the dialogue, set interactions back to true once dialogue is done
        dialoguePanel.SetActive(false);
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    */
}
