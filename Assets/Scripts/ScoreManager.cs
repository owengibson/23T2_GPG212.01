using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GPG212_01
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private TextMeshProUGUI scoreText;

        private float score = 0f;

        private void Update()
        {
            score = cameraTransform.position.x / 5f;
            scoreText.text = score.ToString("0");
        }

        private void SaveScore()
        {
            PlayerPrefs.SetFloat("FinalScore", score);
        }

        private void OnEnable()
        {
            EventManager.OnGameOver += SaveScore;
        }
        private void OnDisable()
        {
            EventManager.OnGameOver -= SaveScore;
        }
    }
}