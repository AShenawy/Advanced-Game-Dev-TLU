using UnityEngine;
using UnityEngine.UI;

public class DlgManSimple : MonoBehaviour
{
    public static DlgManSimple instance;

    [Header("Public Variables")]
    public Canvas dialogueDisplay;
    public Text textDisplay;

    // This is the small [>] button next to dialogue display text
    public Button continueSmall;

    // This is the big invisible button that covers the entire screen
    public Button continueBig;


    [Header("Private Variables")]
    [SerializeField]
    private string[] dialogueLines;

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

    public void StartDialogue(string[] lines)
    {
        if (lines.Length < 1)
        {
            // pieces array is empty and there's no dialogue to display
            // exit the function
            return;
        }
        else if (dialogueLines != null)
        {
            // another dialogue is in progress
            // exit the function
            return;
        }

        dialogueLines = lines;
        AdvanceDialogue();
        ShowDialogueDisplay();
    }

    public void OnContinueButtonClicked()
    {
        if (dialogueProgress < dialogueLines.Length)
        {
            // havent' reached the end of the dialogue lines
            AdvanceDialogue();
        }
        else
        {
            // all dialogue lines exhausted
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
}
