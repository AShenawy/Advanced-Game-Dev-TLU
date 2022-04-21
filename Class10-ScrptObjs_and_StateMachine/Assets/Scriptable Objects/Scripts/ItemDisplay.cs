using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public ItemData itemData;

    [SerializeField] private Text itemText;
    [SerializeField] private Image itemImage;

    void Start()
    {
        itemText.text = itemData.itemName;
        itemImage.sprite = itemData.itemIcon;
    }
}
