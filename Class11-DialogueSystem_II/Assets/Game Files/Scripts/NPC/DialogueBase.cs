using UnityEngine;
using Ink.Runtime;


// This is the base class for NPC dialogues
public class DialogueBase : MonoBehaviour
{
    [SerializeField] private GameObject speechBubblePrefab;
    private GameObject speechBubble;

    // The compiled JSON file which Ink plugin produces from the .ink file
    [SerializeField] private TextAsset inkAsset;

    // Variables from Ink story to store on the character and use later
    protected VariablesState dialogueVariables;

    // protected variables can only be accessed by child classes
    protected bool canSpeak;

    // A shorthand version of a getter property
    public bool CanSpeakTo => canSpeak;

    protected virtual void OnMouseUp()
    {
        StartDialogue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // If the player is within range, allow this NPC's dialogue to start
            canSpeak = true;
            speechBubble = Instantiate(speechBubblePrefab, new Vector3(transform.position.x, transform.position.y + 1.5f), Quaternion.identity, transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // When the player exits the collider's range, prevent it from starting dialogue
            canSpeak = false;
            Destroy(speechBubble);
        }
    }

    public void StartDialogue()
    {
        if (canSpeak)
        {
            InkDialogueManager.instance.StartDialogue(this);
        }
    }

    public TextAsset GetDialogueAsset()
    {
        return inkAsset;
    }

    public VariablesState GetVariables()
    {
        return dialogueVariables;
    }

    // Store variable values at end of dialogue to use in other scripts
    // and update dialogue variables next time it starts
    public virtual void UpdateVariablesState(VariablesState variables)
    {
        dialogueVariables = variables;
    }
}
