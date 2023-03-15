using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Persisting
{
    public class LevelManagerPersist : MonoBehaviour
    {
        // Create a static single instance to access this class/script from anywhere
        public static LevelManagerPersist instance;

        public string previousLevel;
        public string currentLevel;

        public void Awake()
        {
            if (instance == null)
            {
                instance = this;

                // Protect entire game object from being destroyed. This will keep ALL components on the game object
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                // If there's another game object in the scene with this script on it, remove it from the scene
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
}