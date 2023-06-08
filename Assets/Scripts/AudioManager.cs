using GPG212_01;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyAudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;


        [HideInInspector] public Sound mainStart;
        private Sound mainLoop;
        private Sound deathScreen;

        private void Awake()
        {
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
            }
        }

        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }

        private void OnEnable()
        {
            EventManager.PlayAudio += Play;
        }
        private void OnDisable()
        {
            EventManager.PlayAudio -= Play;
        }
    }
}