using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Persisting
{
    // This script doesn't inherit from MonoBehaviour, has static members (variables & functions),
    // and can be accessed from any script in any scene
    // Note: It also lost its ability to use Awake, Start, Update, etc that come from MonoBehaviour
    public class LevelManagerNonMono
    {
        public static string previousLevel;
        public static string currentLevel;

        public static void LoadLevel(string levelName)
        {
            // store current scene name as previous level before loading the new scene
            previousLevel = SceneManager.GetActiveScene().name;

            SceneManager.LoadScene(levelName);

            // store newly loaded scene name as the current level
            currentLevel = levelName;

            Debug.Log("Loaded level: " + levelName + ". Previous level: " + previousLevel);
        }
    }
}