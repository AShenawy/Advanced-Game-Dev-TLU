using UnityEngine;

public class NpcDialogueSimple : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] dialogue;


    private void OnMouseDown()
    {
        DlgManSimple.instance.StartDialogue(dialogue);
    }
}
