using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Game/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int usageCount;
    public int maxAmount;
}
