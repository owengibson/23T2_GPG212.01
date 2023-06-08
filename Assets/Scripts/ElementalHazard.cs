using UnityEngine;

namespace GPG212_01
{
    public class ElementalHazard : MonoBehaviour
    {
        [SerializeField] private Element obstacleElement;
        [SerializeField] private bool isAvoidable;

        private Color fireColor = new Color32(193, 102, 0, 255);
        private Color waterColor = new Color32(0, 75, 140, 255);

        private void Awake()
        {
            Transform obstacleChild = transform.Find("Square");

            if (isAvoidable)
            {
                if (Random.Range(0, 2) == 0)
                {
                    obstacleElement = Element.FIRE;
                    GetComponent<SpriteRenderer>().color = fireColor;
                    if (obstacleChild != null)
                    {
                        obstacleChild.GetComponent<SpriteRenderer>().color = fireColor;
                    }
                }
                else
                {
                    obstacleElement = Element.WATER;
                    GetComponent<SpriteRenderer>().color = waterColor;
                    if (obstacleChild != null)
                    {
                        obstacleChild.GetComponent<SpriteRenderer>().color = waterColor;
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Element playerElement = collision.gameObject.GetComponent<PlayerController>().playerElement;
                if (obstacleElement != playerElement)
                {
                    EventManager.OnGameOver?.Invoke();
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Element playerElement = collision.gameObject.GetComponent<PlayerController>().playerElement;
                if (obstacleElement != playerElement)
                {
                    EventManager.OnGameOver?.Invoke();
                }
            }
        }
    }
}