using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameManager gm;
    public Text levelUIText;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerLevel();
    }

    public void UpdatePlayerLevel()
    {
        // The GameManager abstracts away the details of how the player level is calculated
        // and UIManager only really needs the result -> the player's level
        int level = gm.GetPlayerLevel();
        levelUIText.text = level.ToString();
    }
}
