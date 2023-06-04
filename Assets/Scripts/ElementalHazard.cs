using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPG212_01
{
    public class ElementalHazard : MonoBehaviour
    {
        [SerializeField] private Element obstacleElement;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Element playerElement = collision.gameObject.GetComponent<PlayerController>().playerElement;
                if(obstacleElement != playerElement)
                {
                    EventManager.OnGameOver?.Invoke();
                }
            }
        }
    }
}