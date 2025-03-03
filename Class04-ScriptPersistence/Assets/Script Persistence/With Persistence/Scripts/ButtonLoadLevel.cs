using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Persisting
{
    public class ButtonLoadLevel : MonoBehaviour
    {
        public void OnButtonClickLoadLevel(string levelName)
        {
            // Call the LoadLevel function through the static instance (singleton) variable
            LevelManagerPersist.instance.LoadLevel(levelName);
        }
    }
}