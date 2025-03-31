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

public enum Grade
{
    Normal,
    Rare,
    Epic
}

[CreateAssetMenu(fileName = "New Weapon", menuName = "Game/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string itemName = "The best weapon";
    [SerializeField] Sprite spriteNormal;
    [SerializeField] Sprite spriteRare;
    [SerializeField] Sprite spriteEpic;

    [Tooltip("How many times the item can be used before it's depleted")]
    public int usageCount;

    [Tooltip("The max quantity the player can carry of this item")]
    public int maxAmount;


    public Sprite GetSprite(Grade grade)
    {
        switch (grade)
        {
            case Grade.Normal:
                return spriteNormal;
            case Grade.Rare:
                return spriteRare;
            case Grade.Epic:
                return spriteEpic;
            default:
                Debug.LogWarning("Undefined grade");
                return spriteNormal;
        }
    }
}