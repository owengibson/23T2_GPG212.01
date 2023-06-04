using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPG212_01
{
    public class LevelGenerator : MonoBehaviour
    {
        private const float OBSTACLE_SPAWN_DISTANCE_THRESHOLD = 20f;

        [SerializeField] private GameObject[] levelObstacles;
        [SerializeField] private GameObject player;
        [SerializeField] private Transform obstacleParent;

        private Vector3 _lastObstaclePosition = Vector3.zero;

        private void Update()
        {
            if (Vector3.Distance(player.transform.position, _lastObstaclePosition) < OBSTACLE_SPAWN_DISTANCE_THRESHOLD)
            {
                SpawnLevelObstacle();
            }
        }

        private void SpawnLevelObstacle()
        {
            float obstacleXOffset = Random.Range(10f, 20f);

            GameObject levelObstacle = levelObstacles[Random.Range(0, levelObstacles.Length)];
            GameObject lastObstacle = Instantiate(levelObstacle, new Vector3(_lastObstaclePosition.x + obstacleXOffset, levelObstacle.transform.position.y), Quaternion.identity);
            lastObstacle.transform.SetParent(obstacleParent);
            _lastObstaclePosition = lastObstacle.transform.Find("End Position").position;
        }
    }
}