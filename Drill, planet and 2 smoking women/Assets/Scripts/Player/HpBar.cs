using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public int _curHealth = 0;
    public int _maxHealth = 100;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private GameOverScript gameOverScript;
    //[SerializeField] private Slider _bossBar;
    //[SerializeField] private SpriteRenderer _image;
    //[SerializeField] private Sprite _crashedObservatory;
    //[SerializeField] private BossScript boss;
    //[SerializeField] private LaserScript laser;

    public void Start()
    {
        _curHealth = _maxHealth;
    }

    public void DamagePlayer(int damage)
    {
        _curHealth -= damage;
        _healthBar.value = _curHealth;
        //if (_curHealth <= 25)
        //{
        //    _image.sprite = _crashedObservatory;
        //}
        if (_curHealth <= 0)
        {
            gameOverScript.GameOver();
        }
    }


    //public void BossBar(int health)
    //{
    //    _bossBar.value = health;
    //}
    //public void BossBarMax(int health)
    //{
    //    _bossBar.maxValue = health;
    //    _bossBar.value = health;
    //}
}
