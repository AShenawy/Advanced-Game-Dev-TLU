using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

// This script receives and runs the ink stories compiled in JSON format
public class InkDialogueManager : MonoBehaviour
{
    public static InkDialogueManager instance;

    [Header("Game Elements")]
    public PlayerController player;

    [Header("Prefabs")]
    public DialogueCanvas dialogueCanvasPrefab;
    public Button choiceButtonPrefab;

    [Header("Private Variables")]
    // UI references in dialogue
    [SerializeField] private DialogueCanvas dialogueCanvas;
    [SerializeField] private Text textDisplay;
    [SerializeField] private GameObject choiceButtons;

    // Story and NPC references
    [SerializeField] private DialogueBase dialogueNPC;
    [SerializeField] private Story story;

    // Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && story != null)
        {
            ProgressDialogue();
        }
    }

    // This is where we kick-off a new dialogue
    public void StartDialogue(DialogueBase speaker)
    {
        // Prevent player from moving when dialogue starts
        player.FreezePlayer(true);

        // assign reference to the NPC starting dialogue
        dialogueNPC = speaker;
        
        // Creat a new story to play via the story text file
        TextAsset storyText = speaker.GetDialogueAsset();
        story = new Story(storyText.text);

        // If NPC has story variables, update the story with them before progressing with it
        VariablesState speakerStoryVariables = speaker.GetVariables();
        if (speakerStoryVariables != null)
        {
            UpdateStoryVariables(speakerStoryVariables);
        }

        CreateDialogueUI();
        ProgressDialogue();
    }

    void UpdateStoryVariables(VariablesState npcStoryVariables)
    {
        // VariablesState allows us to iterate over it using a "foreach".
        // The foreach gives us access to the story variables by the names we gave them in Ink
        // 
        // Grab the value of each variable (by its name) and assign it the current story's variables
        foreach (string variable in npcStoryVariables)
        {
            // We obtain the value by passing in the variable's name (like we do in arrays/lists but this time using strings)
            // "variableValueOnNPC" is an "object" data type because the value type can be anything (int, bool, string, etc.) so we use the general "object" type
            object varValueFromNPC = npcStoryVariables[variable];


            // Then we assign the obtained value to the same variable (by its name) that exists in the currently loaded story
            story.variablesState[variable] = varValueFromNPC;
        }
    }

    void CreateDialogueUI()
    {
        dialogueCanvas = Instantiate(dialogueCanvasPrefab);
        textDisplay = dialogueCanvas.dialogueText;
        choiceButtons = dialogueCanvas.dialogueChoices;
    }

    // This where dialogue control decisions are made
    public void ProgressDialogue()
    {
        // If there's another line to show in the story, display it
        if (story.canContinue)
        {
            // Continue() provides the next line and also checks if it can continue after that (there're more lines)
            // or not (there're choices or an END divert in the story)
            textDisplay.text = story.Continue();
        }


        // After Continue(), check if the story reached any choices
        if (story.currentChoices.Count > 0)
        {
            // Create a UI button for every choice availbale
            for (int choiceNum = 0; choiceNum < story.currentChoices.Count; choiceNum++)
            {
                Choice inkChoice = story.currentChoices[choiceNum];
                Button choiceButton = CreateChoiceButton(inkChoice.text);


                // Add an OnClick listener from code, since we can't access the button component in inspector during gameplay
                // This is an Anonymous Function which is only called when the button is clicked (onCLick). When called, it performs
                // what's after the arrow "=>". In this case, it's calling SelectChoice
                choiceButton.onClick.AddListener(() => SelectChoice(inkChoice.index));
            }
        }
        else if (!story.canContinue)
        {
            // If there aren't choices and the story still can't continue, it reached the end
            EndDialogue();
        }
    }

    Button CreateChoiceButton(string choiceText)
    {
        // Instantiate the button prefab and make it a child of Choice Buttons
        Button button = Instantiate(choiceButtonPrefab, choiceButtons.transform);

        // Make the button's text that of the dialogue choice
        button.GetComponentInChildren<Text>().text = choiceText;
        return button;
    }

    void SelectChoice(int choiceIndex)
    {
        // Tell the story which choice player has made
        story.ChooseChoiceIndex(choiceIndex);

        RefreshScreen();

        // Since player made their choice, we can continue with the story
        ProgressDialogue();
    }

    void RefreshScreen()
    {
        // Clear displayed choices
        foreach (Transform choiceButton in choiceButtons.transform)
        {
            Destroy(choiceButton.gameObject);
        }

        // Clear displayed text
        textDisplay.text = "";
    }

    void EndDialogue()
    {
        // Send the NPC which started the dialogue the latest state of their story variables
        dialogueNPC.UpdateVariablesState(story.variablesState);
        
        // Remove dialogue UI and clear the current story
        RefreshScreen();
        Destroy(dialogueCanvas.gameObject); // Since dialogueCanvas sits on the top dialogue game object, all UI is destoryed
        story = null;

        // Allow player to move again
        player.FreezePlayer(false);
    }
}
