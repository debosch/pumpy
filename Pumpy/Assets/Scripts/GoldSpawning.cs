using UnityEngine;

public class GoldSpawning : MonoBehaviour
{

    [SerializeField] private Transform gold;

    [SerializeField] private Transform spawnPointsHolder;

    private Transform[] spawnPoints;

    private float timeToSpawn = 1f;

    private void Start()
    {
        int spawnPointsCount = 30;

        spawnPoints = new Transform[spawnPointsCount];

        for (int i = 0; i < spawnPointsCount; i++)
            spawnPoints[i] = spawnPointsHolder.transform.GetChild(i);
    }

    private void Update()
    {
        if (timeToSpawn < 0)
        {
            var randomPoint = Random.Range(0,spawnPoints.Length);
           
            Instantiate(gold, spawnPoints[randomPoint].position, Quaternion.identity);

            timeToSpawn = Random.Range(0.5f, 1.5f);
        }
        else
            timeToSpawn -= Time.deltaTime;
        
    }
}
