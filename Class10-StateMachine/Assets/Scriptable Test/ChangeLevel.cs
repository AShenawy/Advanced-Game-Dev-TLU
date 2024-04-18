using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public void Change(string levelName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}
