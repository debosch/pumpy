using UnityEngine;

public class GoldSpawning : MonoBehaviour
{

    [SerializeField] private GameObject gold;

    [SerializeField] private Transform[] spawnPoints;

    private float timeToSpawn = .5f;

    private void Update()
    {
        if (timeToSpawn < 0)
        {
            var randomPoint = Random.Range(0,spawnPoints.Length);

            Instantiate(gold, spawnPoints[randomPoint].position, Quaternion.identity);

            timeToSpawn = .5f;
        }
        else
            timeToSpawn -= Time.deltaTime;
        
    }
}
