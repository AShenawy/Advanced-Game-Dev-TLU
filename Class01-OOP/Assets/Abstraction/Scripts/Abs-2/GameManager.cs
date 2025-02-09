using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int xpPerLevel;  // How much experience points before levelling up

    // The SerializeField attribute makes the variable under it (currentXp in this case)
    // become visible in Unity's inspector, even when it's private in the code.
    [SerializeField]     
    private int currentXp;


    public int GetPlayerLevel()
    {
        // We _Cast_ the int type variable 'currentXp' to float type to correctly calculate the division
        // withouth rounding it down automatically (something that ints do as they cannot have fractions)
        float currentLevel = (float)currentXp / xpPerLevel;
        return Mathf.CeilToInt(currentLevel);
    }
}
