using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameConfiguration
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource soundSource;

        public ConfigSaveManager saveManager;

        void Start()
        {
            LoadGameSettings();
        }

        void LoadGameSettings()
        {
            float volumeLevel = saveManager.GetPrefFloat("volume");
            if (volumeLevel > -1)
            {
                print("Found volume setting: " + volumeLevel);
                soundSource.volume = volumeLevel;
            }
            else
            {
                soundSource.volume = 1;
            }


            bool muteValue = saveManager.GetPrefBool("isMuted");
            if (muteValue)
            {
                print("Found mute setting: true");
            }
            AudioListener.volume = muteValue ? 0f : 1f;
        }

        public void SetVolume(float level)
        {
            soundSource.volume = level;
        }

        public void SetMuted(bool isMuted)
        {
            AudioListener.volume = isMuted ? 0f : 1f;
        }
    }
}