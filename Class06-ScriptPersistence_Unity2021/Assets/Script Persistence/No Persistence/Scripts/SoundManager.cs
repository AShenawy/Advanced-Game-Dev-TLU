using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NonPersisting
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource bgmPlayer;

        void Start()
        {
            bgmPlayer.Play();
        }
    }
}