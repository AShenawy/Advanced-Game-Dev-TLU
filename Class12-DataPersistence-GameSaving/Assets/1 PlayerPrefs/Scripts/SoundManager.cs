using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameConfiguration
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource soundSource;

        public ConfigSaveManager saveManager;

        void Awake()
        {
            LoadGameSettings();
        }

        void LoadGameSettings()
        {
            float volumeLevel = saveManager.GetPrefFloat("volume");
            if (volumeLevel > -1)
            {
                print("Found volume setting: " + volumeLevel);
                SetVolume(volumeLevel);
            }
            else
            {
                SetVolume(1);
            }


            bool muteValue = saveManager.GetPrefBool("isMuted");
            if (muteValue)
            {
                print("Found mute setting: true");
            }
            SetMuted(muteValue);
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