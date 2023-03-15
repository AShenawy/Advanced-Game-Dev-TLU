using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLoadLevel : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        LevelManagerPersist.instance.LoadLevel(levelName);
    }
}
