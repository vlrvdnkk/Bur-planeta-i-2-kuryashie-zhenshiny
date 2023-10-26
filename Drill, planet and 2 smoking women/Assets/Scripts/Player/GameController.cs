using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _enemy;
    [SerializeField] private Transform _bigEnemy;
    private float _timeBeforeSpawning = 1.5f;
    private float _timeBetweenEnemies = 0.25f;
    private float _timeBeforeWaves = 2.0f;
    public int enemiesPerWave = 6;
    public int currentNumberOfEnemies = 0;
    public int score = 0;
    [SerializeField] private int _waveNumber = 0;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private EnemyScript _enemyScr;
    //[SerializeField] private BossScript _bossScr;
    [SerializeField] private MoveTowardsPlayer _moveTw;
    [SerializeField] private float spawnRange = 5.0f; // Диапазон для спавна врагов
    [SerializeField] private Transform spawnZoneLeft; // Зона спавна слева
    [SerializeField] private Transform spawnZoneRight; // Зона спавна справа


    void Start()
    {
        _enemyScr.health = 2;
        _moveTw.speed = 0.5f;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(_timeBeforeSpawning);
        while (true)
        {
            if (currentNumberOfEnemies <= 0)
            {
                _waveNumber++;
                _enemyScr.health = Convert.ToInt32(Math.Round(Convert.ToDouble(_enemyScr.health) * 1.45));
                _moveTw.speed = _moveTw.speed * 1.1f;
                enemiesPerWave = Convert.ToInt32(Math.Round(Convert.ToDouble(enemiesPerWave) * 1.1));
                if (_waveNumber < 10)
                    _waveText.text = "00" + _waveNumber;
                else if (_waveNumber < 100 & _waveNumber >= 10)
                    _waveText.text = "0" + _waveNumber;
                else if (_waveNumber < 1000 & _waveNumber >= 100)
                    _waveText.text = "" + _waveNumber;
                else
                    _waveText.text = "end";
                //if (_waveNumber % 10 == 0)
                //{
                //    Transform enemy = Instantiate(_bigEnemy, new Vector3(1.8f, 6.1f, 0), this.transform.rotation);
                //    enemy.parent = transform;
                //    currentNumberOfEnemies += enemiesPerWave;
                //    _bossScr.health *= 2;
                //}
                //else
                //{
                    //float randDirection;
                    //float randDistance;
                    for (int i = 0; i < enemiesPerWave; i++)
                    {
                        // Рассчитываем случайные позиции для спавна врагов в зонах
                        float randomXLeft = Random.Range(-spawnRange, 0f);
                        float randomXRight = Random.Range(0f, spawnRange);
                        float randomYLeft = Random.Range(-spawnRange, 6f);
                        float randomYRight = Random.Range(6f, spawnRange);
                        Vector3 spawnPositionLeft = spawnZoneLeft.position + new Vector3(randomXLeft, randomYLeft, 0f);
                        Vector3 spawnPositionRight = spawnZoneRight.position + new Vector3(randomXRight, randomYRight, 0f);
                        // Создаем врагов в случайных позициях в обеих зонах
                        if (currentNumberOfEnemies < enemiesPerWave - 1)
                        {
                            Instantiate(_enemy, spawnPositionLeft, Quaternion.identity);
                            Instantiate(_enemy, spawnPositionRight, Quaternion.identity);
                            currentNumberOfEnemies += 2;
                            yield return new WaitForSeconds(_timeBetweenEnemies);
                        }
                        else
                        {
                            // Если остался последний враг, то он может быть спавнен в любой из зон
                            if (Random.Range(0, 2) == 0)
                            {
                                Instantiate(_enemy, spawnPositionLeft, Quaternion.identity);
                            }
                            else
                            {
                                Instantiate(_enemy, spawnPositionRight, Quaternion.identity);
                            }
                            currentNumberOfEnemies++;
                            yield return new WaitForSeconds(_timeBetweenEnemies);
                        }



                        //randDistance = Random.Range(5, 15);
                        //randDirection = Random.Range(45, 125);
                        //float posX = this.transform.position.x + (Mathf.Cos((randDirection) * Mathf.Deg2Rad) * randDistance);
                        //float posY = this.transform.position.y + (Mathf.Sin((randDirection) * Mathf.Deg2Rad) * randDistance);
                        //Transform enemySmall = Instantiate(_enemy, new Vector3(posX, posY, 0), this.transform.rotation);
                        //enemySmall.parent = transform;
                        //currentNumberOfEnemies++;
                        //yield return new WaitForSeconds(_timeBetweenEnemies);
                    }
                //}
            }
            yield return new WaitForSeconds(_timeBeforeWaves);
        }
    }

    public void KilledEnemy()
    {
        currentNumberOfEnemies--;
    }

    public void IncreaseScore(int increase)
    {
        score += increase;
        if (score < 10)
            _scoreText.text = "00" + score;
        else if (score < 100 & score >= 10)
            _scoreText.text = "0" + score;
        else if (score < 1000 & score >= 100)
            _scoreText.text = "" + score;
        else
            _scoreText.text = "999";
    }

    public void Red()
    {
        _scoreText.color = new Color(255, 0, 0);
        StartCoroutine(Timer());

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        _scoreText.color = new Color(255, 255, 255);
    }
}