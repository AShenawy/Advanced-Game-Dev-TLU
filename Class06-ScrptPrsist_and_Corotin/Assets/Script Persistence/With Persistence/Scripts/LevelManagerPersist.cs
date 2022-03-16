using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerPersist : MonoBehaviour
{
    public static LevelManagerPersist instance;

    public string previousLevel;
    public string currentLevel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // Protect entire game object from being destroyed. This will keep ALL components on the game object
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(string levelName)
    {
        // store current scene name as previous level before loading the new scene
        previousLevel = SceneManager.GetActiveScene().name;
        
        SceneManager.LoadScene(levelName);

        // store newly loaded scene name as the current level
        currentLevel = levelName;
    }
}
