using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private MenuTrigger menuTrigger;
    [SerializeField] private GameObject enemyPrefabLeft;
    [SerializeField] private GameObject enemyPrefabRight;
    private float timeBeforeSpawning = 1.5f;
    private float timeBetweenEnemies = 0.25f;
    private float timeBeforeWaves = 2;
    public int EnemiesPerWave = 3;
    public int CurrentNumberOfEnemies = 0;
    public int Score = 0;
    [SerializeField] private int waveNumber = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private EnemyScript enemyScr;
    [SerializeField] private MoveTowardsPlayer moveTw;
    [SerializeField] private float spawnRange = 5;
    [SerializeField] private Transform spawnZoneLeft;
    [SerializeField] private Transform spawnZoneRight;


    void Start()
    {
        enemyScr.Health = 2;
        moveTw.Speed = 0.5f;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(timeBeforeSpawning);
        while (true)
        {
            if (CurrentNumberOfEnemies <= 0)
            {
                menuTrigger.UpMenu();
                waveNumber++;
                enemyScr.Health = Convert.ToInt32(Math.Round(Convert.ToDouble(enemyScr.Health) * 1.45));
                moveTw.Speed = moveTw.Speed * 1.1f;
                EnemiesPerWave = Convert.ToInt32(Math.Round(Convert.ToDouble(EnemiesPerWave) * 1.2));
                if (waveNumber < 10)
                    waveText.text = "00" + waveNumber;
                else if (waveNumber < 100 & waveNumber >= 10)
                    waveText.text = "0" + waveNumber;
                else if (waveNumber < 1000 & waveNumber >= 100)
                    waveText.text = "" + waveNumber;
                else
                    waveText.text = "end";
                    for (int i = 0; i < EnemiesPerWave; i++)
                    {
                        float randomXLeft = Random.Range(-spawnRange, 0f);
                        float randomXRight = Random.Range(0f, spawnRange);
                        float randomYLeft = Random.Range(-spawnRange, 6f);
                        float randomYRight = Random.Range(6f, spawnRange);
                        Vector3 spawnPositionLeft = spawnZoneLeft.position + new Vector3(randomXLeft, randomYLeft, 0f);
                        Vector3 spawnPositionRight = spawnZoneRight.position + new Vector3(randomXRight, randomYRight, 0f);
                        if (CurrentNumberOfEnemies < EnemiesPerWave - 1)
                        {
                            Instantiate(enemyPrefabLeft, spawnPositionLeft, Quaternion.identity);
                            Instantiate(enemyPrefabRight, spawnPositionRight, Quaternion.identity);
                            CurrentNumberOfEnemies += 2;
                            yield return new WaitForSeconds(timeBetweenEnemies);
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
                            CurrentNumberOfEnemies++;
                            yield return new WaitForSeconds(timeBetweenEnemies);
                        }
                    }
            }
            yield return new WaitForSeconds(timeBeforeWaves);
        }
    }

    public void KilledEnemy()
    {
        CurrentNumberOfEnemies--;
    }

    public void IncreaseScore(int increase)
    {
        Score += increase;
        if (Score < 10)
            scoreText.text = "00" + Score;
        else if (Score < 100 & Score >= 10)
            scoreText.text = "0" + Score;
        else if (Score < 1000 & Score >= 100)
            scoreText.text = "" + Score;
        else
            scoreText.text = "999";
    }

    public void Red()
    {
        scoreText.color = new Color(255, 0, 0);
        StartCoroutine(Timer());

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        scoreText.color = new Color(255, 255, 255);
    }
}