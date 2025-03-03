using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NonPersisting
{
    public class LevelManager : MonoBehaviour
    {
        public string previousLevel;
        public string currentLevel;

        // Unity button action
        public void LoadLevel(string levelName)
        {
            print("Loading new level: " + levelName);

            // store current scene name as previous level before loading the new scene
            previousLevel = SceneManager.GetActiveScene().name;
            print("Previously loaded level was: " + previousLevel);

            SceneManager.LoadScene(levelName);

            // store newly loaded scene name as the current level
            currentLevel = levelName;
            print($"New level: {levelName} is loaded");
        }
    }
}