using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameConfiguration
{
    public class ConfigSaveManager : MonoBehaviour
    {
        // Save Integers
        public void SetPrefInt(string name, int value)
        {
            PlayerPrefs.SetInt(name, value);
        }

        public int GetPrefInt(string name)
        {
            if (PlayerPrefs.HasKey(name))
            {
                return PlayerPrefs.GetInt(name);
            }
            else
            {
                Debug.LogWarning("Player prefs key " + name + " not found");
                return -1;
            }
        }


        // Save Floats
        public void SetPrefFloat(string name, float value)
        {
            PlayerPrefs.SetFloat(name, value);
        }

        public float GetPrefFloat(string name)
        {
            if (PlayerPrefs.HasKey(name))
            {
                return PlayerPrefs.GetFloat(name);
            }
            else
            {
                Debug.LogWarning("Player prefs key " + name + " not found");
                return -1f;
            }
        }


        // Save Strings
        public void SetPrefString(string name, string value)
        {
            PlayerPrefs.SetString(name, value);
        }

        public string GetPrefString(string name)
        {
            if (PlayerPrefs.HasKey(name))
            {
                return PlayerPrefs.GetString(name);
            }
            else
            {
                Debug.LogWarning("Player prefs key " + name + " not found");
                return "";
            }
        }


        // Save Booleans
        public void SetPrefBool(string name, bool value)
        {
            // Can be this way
            if (value == true)
            {
                PlayerPrefs.SetInt(name, 1);
            }
            else
            {
                PlayerPrefs.SetInt(name, 0);
            }


            // OR this way: Ternary operator
            int ternaryBool = value ? 1 : 0;
            PlayerPrefs.SetInt(name, ternaryBool);


            // OR this way: C# Convert class
            int convertedBool = System.Convert.ToInt32(value);
            PlayerPrefs.SetInt(name, convertedBool);
        }

        public bool GetPrefBool(string name)
        {
            if (PlayerPrefs.HasKey(name))
            {
                int intValue = PlayerPrefs.GetInt(name);

                // Can be this way
                if (intValue == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


                // OR this way: Ternary operator
                return intValue == 1 ? true : false;


                // OR this way: C# Convert class
                bool convertedInt = System.Convert.ToBoolean(intValue);
                return convertedInt;
            }
            else
            {
                // Unfortunately we have to return either true/false which is still a valid value and be misinterpreted
                // (We can also throw a game-stopping exception error)
                
                Debug.LogWarning("Player prefs key " + name + " not found");
                return false;
            }
        }

        public void ResetAll()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
