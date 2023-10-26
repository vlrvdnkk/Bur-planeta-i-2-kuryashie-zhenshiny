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
    public int enemiesPerWave = 5;
    public int currentNumberOfEnemies = 0;
    public int score = 0;
    [SerializeField] private int _waveNumber = 0;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private EnemyScript _enemyScr;
    [SerializeField] private BossScript _bossScr;
    [SerializeField] private MoveTowardsPlayer _moveTw;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {

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
                if (_waveNumber % 10 == 0)
                {
                    Transform enemy = Instantiate(_bigEnemy, new Vector3(1.8f, 6.1f, 0), this.transform.rotation);
                    enemy.parent = transform;
                    currentNumberOfEnemies += enemiesPerWave;
                    _bossScr.health *= 2;
                }
                else
                {
                    float randDirection;
                    float randDistance;
                    for (int i = 0; i < enemiesPerWave; i++)
                    {
                        randDistance = Random.Range(5, 15);
                        randDirection = Random.Range(45, 125);
                        float posX = this.transform.position.x + (Mathf.Cos((randDirection) * Mathf.Deg2Rad) * randDistance);
                        float posY = this.transform.position.y + (Mathf.Sin((randDirection) * Mathf.Deg2Rad) * randDistance);
                        Transform enemySmall = Instantiate(_enemy, new Vector3(posX, posY, 0), this.transform.rotation);
                        enemySmall.parent = transform;
                        currentNumberOfEnemies++;
                        yield return new WaitForSeconds(_timeBetweenEnemies);
                    }
                }
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
