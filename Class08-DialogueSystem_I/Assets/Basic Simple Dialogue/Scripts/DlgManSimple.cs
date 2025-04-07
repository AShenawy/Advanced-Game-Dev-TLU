using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DlgManSimple : MonoBehaviour
{
    public static DlgManSimple instance;

    [Header("Public Variables")]
    public Canvas dialogueDisplay;

    [Tooltip("Your dialogue text goes here")]
    public Text textDisplay;

    [Tooltip("This is the small [>] button next to dialogue display text")]
    public Button continueSmall;

    [Tooltip("This is the big invisible button that covers the entire screen")]
    public Button continueBig;


    [Header("Private Variables")]
    [SerializeField]
    private List<string> dialogueLines;

    [SerializeField]
    private int dialogueProgress = 0;


    // Make dialogue manager a singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Clear dialogue text
        ClearText();

        // Hide dialogue canvas
        HideDialogueDisplay();
    }

    private void ClearText()
    {
        textDisplay.text = "";
        dialogueLines = null;
    }

    private void ShowDialogueDisplay()
    {
        dialogueDisplay.gameObject.SetActive(true);
    }

    private void HideDialogueDisplay()
    {
        dialogueDisplay.gameObject.SetActive(false);
    }

    public void StartDialogue(List<string> lines)
    {
        if (lines.Count < 1)
        {
            // Incoming lines list is empty. No dialogue to display
            // Exit the function
            Debug.LogWarning("No dialogue lines given");
            return;
        }
        else if (dialogueLines != null)
        {
            // Another dialogue is in progress
            // Exit the function
            Debug.LogWarning("A dialogue is already in progress");
            return;
        }

        dialogueLines = lines;
        AdvanceDialogue();
        ShowDialogueDisplay();
    }

    // Called from canvas button(s)
    public void OnContinueButtonClicked()
    {
        if (dialogueProgress < dialogueLines.Count)
        {
            // More dialogue lines remaining
            AdvanceDialogue();
        }
        else
        {
            // All dialogue lines exhausted
            EndDialogue();
        }
    }

    private void AdvanceDialogue()
    {
        textDisplay.text = dialogueLines[dialogueProgress];
        dialogueProgress++;
    }

    private void EndDialogue()
    {
        HideDialogueDisplay();
        ClearText();
        dialogueProgress = 0;
    }
}
