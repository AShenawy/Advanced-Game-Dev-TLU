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
            // store current scene name as previous level before loading the new scene
            previousLevel = SceneManager.GetActiveScene().name;

            SceneManager.LoadScene(levelName);

            // store newly loaded scene name as the current level
            currentLevel = levelName;
        }
    }
}