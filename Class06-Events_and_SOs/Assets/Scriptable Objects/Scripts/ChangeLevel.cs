using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public void Change(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
