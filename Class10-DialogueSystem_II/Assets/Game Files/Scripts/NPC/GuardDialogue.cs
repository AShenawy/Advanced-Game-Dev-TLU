using UnityEngine;
using Ink.Runtime;

public class GuardDialogue : DialogueBase
{
    [Header("NPC-Specific Params")]
    [SerializeField] private int visitCount;
    [SerializeField] private bool isHostile;
    [SerializeField] private bool hasGivenTrinket;

    private bool playerGotTrinket = false;

    // A shorthand version of a getter property using Lambda operator. This version doesn't allow a setter
    public bool IsFirstVisit => visitCount < 1;

    // Another shorthand version of a getter property. This version allows a setter
    public bool IsHostile
    {
        get => isHostile;
        set => isHostile = value;
    }

    // Specific variables for this guard script are handled here
    public override void UpdateVariablesState(VariablesState variables)
    {
        base.UpdateVariablesState(variables);

        visitCount = (int)variables["visitCount"];
        isHostile = (bool)variables["isHostile"];
        hasGivenTrinket = (bool)variables["hasGivenTrinket"];

        PerformDialogueActions();
    }

    // Specific methods for this guard npc
    protected override void PerformDialogueActions()
    {
        // playerGotTrinket prevents giving player the trinket more than once
        if (hasGivenTrinket && !playerGotTrinket)
        {
            playerGotTrinket = true;

            // Give player trinket item through method call to Game Manager or Inventory Manager
            print("Player got trinket!");
        }
    }

    public bool GavePlayerTrinket()
    {
        return hasGivenTrinket;
    }
}
