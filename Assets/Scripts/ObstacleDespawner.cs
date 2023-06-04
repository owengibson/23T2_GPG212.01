using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPG212_01
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ObstacleDespawner : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}