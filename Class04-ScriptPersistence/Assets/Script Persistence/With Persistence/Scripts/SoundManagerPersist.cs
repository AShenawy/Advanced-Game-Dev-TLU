using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Persisting
{
    public class SoundManagerPersist : MonoBehaviour
    {
        public static SoundManagerPersist instance;
        public AudioSource bgmPlayer;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;

                // Protect entire game object from being destroyed. This will keep ALL components on the game object
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            bgmPlayer.Play();
        }
    }
}