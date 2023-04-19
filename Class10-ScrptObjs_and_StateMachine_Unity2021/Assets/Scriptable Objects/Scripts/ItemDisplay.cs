using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public ItemData itemData;

    [SerializeField] private Text itemText;
    [SerializeField] private Image itemImage;
    [SerializeField] private Text usesText;

    [SerializeField] private Text messageText;

    private int usesLeft;
    private int stackCount;

    void Start()
    {
        ClearItem();
    }

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

    public void ClearItem()
    {
        itemData = null;
        itemText.text = "";
        itemImage.sprite = null;
        usesLeft = 0;
        stackCount = 0;

        if (usesText)
        {
            usesText.text = "";
        }

        if (messageText)
        {
            messageText.text = "";
        }
    }

    public void ModifyName(string newName)
    {
        itemData.itemName = newName;
        itemText.text = newName;
    }
}
