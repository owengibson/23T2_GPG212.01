using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPG212_01
{
    public class EventManager : MonoBehaviour
    {
        public static Action OnGameOver;
        public static Action<string> PlayAudio;
    }
}