using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Persisting
{
    public class ButtonLoadLevel : MonoBehaviour
    {
        public void LoadLevel(string levelName)
        {
            // Call the LoadLevel function through the static instance variable
            LevelManagerPersist.instance.LoadLevel(levelName);
        }
    }
}