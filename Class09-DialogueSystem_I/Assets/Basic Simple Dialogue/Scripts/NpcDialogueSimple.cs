using System.Collections.Generic;
using UnityEngine;

public class NpcDialogueSimple : MonoBehaviour
{
    [TextArea(2, 5)]
    public List<string> dialogue;


    private void OnMouseDown()
    {
        DlgManSimple.instance.StartDialogue(dialogue);
    }
}
