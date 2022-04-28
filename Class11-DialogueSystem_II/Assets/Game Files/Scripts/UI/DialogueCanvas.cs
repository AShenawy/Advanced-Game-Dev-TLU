using UnityEngine;
using UnityEngine.UI;


// This scripts sits on the top Canvas game object & just holds references to child game objects,
// making it easier for Dialogue Manager to grab them after instantiation
public class DialogueCanvas : MonoBehaviour
{
    public Text dialogueText;
    public GameObject dialogueChoices;
}
