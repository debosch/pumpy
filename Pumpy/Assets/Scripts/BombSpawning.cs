using UnityEngine;

public class BombSpawning : MonoBehaviour
{
    [SerializeField] private Transform bomb;

    [SerializeField] private Transform bombHolder;

    private Transform[] bombSpawnPoints;

    private float timeUntilSpawn = 1f;

    private void Start()
    {
        int bombCount = 17;

        bombSpawnPoints = new Transform[bombCount]; 

        for (int i = 0; i < bombCount; i++)
            bombSpawnPoints[i] = bombHolder.transform.GetChild(i);
    }

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
