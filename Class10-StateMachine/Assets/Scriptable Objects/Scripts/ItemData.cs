using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Game/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    
    [Tooltip("How many times the item can be used before it's depleted")]
    public int usageCount;

    [Tooltip("The max quantity the player can carry of this item")]
    public int maxAmount;
}
