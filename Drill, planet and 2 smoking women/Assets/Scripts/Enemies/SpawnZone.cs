using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private Transform drill;
    [SerializeField] private GameObject enemyPrefabLeft;
    [SerializeField] private GameObject enemyPrefabRight;
    [SerializeField] private float spawnInterval = 5;
    [SerializeField] private float spawnRange = 5;
    [SerializeField] private Transform spawnZoneLeft;
    [SerializeField] private Transform spawnZoneRight;
    [SerializeField] private int totalEnemiesToSpawn = 10;

    private float spawnTimer = 0.0f;
    private int enemiesSpawned = 0;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval && enemiesSpawned < totalEnemiesToSpawn)
        {
            SpawnEnemy();
            spawnTimer = 0.0f;
        }
    }

    private void SpawnEnemy()
    {
        float randomXLeft = Random.Range(-spawnRange, 0f);
        float randomXRight = Random.Range(0f, spawnRange);
        Vector3 spawnPositionLeft = spawnZoneLeft.position + new Vector3(randomXLeft, 0f, 0f);
        Vector3 spawnPositionRight = spawnZoneRight.position + new Vector3(randomXRight, 0f, 0f);

        if (enemiesSpawned < totalEnemiesToSpawn - 1)
        {
            Instantiate(enemyPrefabLeft, spawnPositionLeft, Quaternion.identity);
            Instantiate(enemyPrefabRight, spawnPositionRight, Quaternion.identity);
            enemiesSpawned += 2;
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(enemyPrefabLeft, spawnPositionLeft, Quaternion.identity);
            }
            else
            {
                Instantiate(enemyPrefabRight, spawnPositionRight, Quaternion.identity);
            }
            enemiesSpawned++;
        }
    }
}