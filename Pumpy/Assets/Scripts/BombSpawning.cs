using UnityEngine;

public class BombSpawning : MonoBehaviour
{
    [SerializeField] private Transform bomb;

    [SerializeField] private Transform[] bombSpawnPoints;

    private float timeUntilSpawn = 1f;
    
    private void Update()
    {
        if (timeUntilSpawn <= 0)
        {
            var randPoint = Random.Range(0, bombSpawnPoints.Length);

            Instantiate(bomb, bombSpawnPoints[randPoint].position, Quaternion.identity);

            timeUntilSpawn = 1f;
        }
        else
            timeUntilSpawn -= Time.deltaTime;
    }
}
