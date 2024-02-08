using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameConfiguration
{
    public class GameSettingsManager : MonoBehaviour
    {
        public Slider volumeSlider;
        public Toggle muteToggle;

        public SoundManager soundManager;
        public ConfigSaveManager saveManager;

        void Start()
        {
            LoadGameSettings();
        }

        void LoadGameSettings()
        {
            float volumeLevel = saveManager.GetPrefFloat("volume");

            // Check if the value is valid before using it
            if (volumeLevel > -1f)
            {
                volumeSlider.value = volumeLevel;
            }
            else
            {
                // If a saved value wasn't found, use a default value
                volumeSlider.value = 1f;
            }


            bool muteValue = saveManager.GetPrefBool("isMuted");
            muteToggle.isOn = muteValue;
        }

        public void UpdateVolumeState(float level)
        {
            soundManager.SetVolume(level);
            saveManager.SetPrefFloat("volume", level);
        }

        public void UpdateMutedState(bool isMuted)
        {
            soundManager.SetMuted(isMuted);
            saveManager.SetPrefBool("isMuted", isMuted);
        }
    }
}
