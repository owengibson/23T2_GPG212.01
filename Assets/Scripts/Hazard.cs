using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPG212_01
{
    [RequireComponent(typeof(Collider2D))]
    public class Hazard : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                EventManager.OnGameOver?.Invoke();
            }
        }
    }
}