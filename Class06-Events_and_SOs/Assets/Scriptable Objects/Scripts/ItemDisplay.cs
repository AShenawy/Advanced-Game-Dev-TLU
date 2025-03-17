using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public ItemData itemData;

    [SerializeField] private Text itemText;
    [SerializeField] private Image itemImage;
    [SerializeField] private Sprite unequippedSprite;
    [SerializeField] private Text usesText;

    [SerializeField] private Text messageText;

    private int usesLeft;
    private int stackCount;

    void Start()
    {
        // Start with a clear display
        Clear();
    }

    // Unity Button trigger
    public void SetItem(ItemData item)
    {
        if (stackCount < item.maxAmount)
        {
            stackCount++;

            // Check if variable is assigned
            if (messageText)
            {
                messageText.text = "Equipped " + item.itemName + "\nHas " + stackCount;
            }
        }
        else
        {
            if (messageText)
            {
                messageText.text = "Can't equip more of " + item.itemName;
            }
        }

        itemData = item;
        itemText.text = item.itemName;
        itemImage.sprite = item.itemIcon;
        usesLeft = item.usageCount;

        if (usesText)
        {
            usesText.text = item.usageCount.ToString();
        }
    }

    // Unity Button trigger
    public void ConsumeItem()
    {
        if (itemData != null && usesLeft > 0)
        {
            if (messageText)
            {
                messageText.text = "Used " + itemData.itemName;
            }

            usesLeft--;

            if (usesText)
            {
                usesText.text = usesLeft.ToString();
            }
        }
        else
        {
            if (messageText)
            {
                messageText.text = "";
            }
        }
    }

    // Unity Button trigger
    public void Clear()
    {
        itemData = null;
        itemText.text = "Nothing Equipped";
        itemImage.sprite = unequippedSprite;
        usesLeft = 0;
        stackCount = 0;

        if (usesText)
        {
            usesText.text = "--";
        }

        if (messageText)
        {
            messageText.text = "";
        }
    }

    // Unity Button trigger
    public void ModifyName(string newName)
    {
        itemData.itemName = newName;
        itemText.text = newName;
    }
}
