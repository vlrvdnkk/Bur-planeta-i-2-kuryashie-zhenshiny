using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private Transform drill; // Бур
    [SerializeField] private GameObject enemyPrefabLeft; // Префаб врагов
    [SerializeField] private GameObject enemyPrefabRight; // Префаб врагов
    [SerializeField] private float spawnInterval = 5.0f; // Интервал между спавнами врагов
    [SerializeField] private float spawnRange = 5.0f; // Диапазон для спавна врагов
    [SerializeField] private Transform spawnZoneLeft; // Зона спавна слева
    [SerializeField] private Transform spawnZoneRight; // Зона спавна справа
    [SerializeField] private int totalEnemiesToSpawn = 10; // Общее количество врагов для спавна

    private float spawnTimer = 0.0f;
    private int enemiesSpawned = 0;

    private void Update()
    {
        // Обновляем таймер спавна
        spawnTimer += Time.deltaTime;

        // Если прошло достаточно времени для спавна и есть еще враги для спавна
        if (spawnTimer >= spawnInterval && enemiesSpawned < totalEnemiesToSpawn)
        {
            SpawnEnemy();
            spawnTimer = 0.0f;
        }
    }

    private void SpawnEnemy()
    {
        // Рассчитываем случайные позиции для спавна врагов в зонах
        float randomXLeft = Random.Range(-spawnRange, 0f);
        float randomXRight = Random.Range(0f, spawnRange);
        Vector3 spawnPositionLeft = spawnZoneLeft.position + new Vector3(randomXLeft, 0f, 0f);
        Vector3 spawnPositionRight = spawnZoneRight.position + new Vector3(randomXRight, 0f, 0f);

        // Создаем врагов в случайных позициях в обеих зонах
        if (enemiesSpawned < totalEnemiesToSpawn - 1)
        {
            Instantiate(enemyPrefabLeft, spawnPositionLeft, Quaternion.identity);
            Instantiate(enemyPrefabRight, spawnPositionRight, Quaternion.identity);
            enemiesSpawned += 2;
        }
        else
        {
            // Если остался последний враг, то он может быть спавнен в любой из зон
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