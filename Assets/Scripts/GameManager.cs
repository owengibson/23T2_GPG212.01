using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GPG212_01
{
    public class GameManager : MonoBehaviour
    {
        public void LoadMainScene() => SceneManager.LoadScene("Main");

        public void LoadDeathSceen() => SceneManager.LoadScene("DeathScreen");

        private void OnEnable()
        {
            EventManager.OnGameOver += LoadDeathSceen;
        }
        private void OnDisable()
        {
            EventManager.OnGameOver -= LoadDeathSceen;
        }

    }
}