using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GPG212_01
{
    public class DeathScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        void Start()
        {
            scoreText.text = PlayerPrefs.GetFloat("FinalScore").ToString("0");
        }

        public void PlayAgain()
        {
            SceneManager.LoadScene("Main");
        }
    }
}