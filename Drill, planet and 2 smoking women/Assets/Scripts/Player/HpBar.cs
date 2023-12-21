using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;   
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameOverPanel gameOverPanel;
    //[SerializeField] private SpriteRenderer _image;
    //[SerializeField] private Sprite _crashedObservatory;
    //[SerializeField] private Animator anim;
    //[SerializeField] private BossScript boss;
    //[SerializeField] private LaserScript laser;

    public void Start()
    {
        curHealth = maxHealth;
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        healthBar.value = curHealth;
        //if (_curHealth <= 25)
        //{
        //    _image.sprite = _crashedObservatory;
        //}
        if (curHealth <= 0)
        {
            gameOverPanel.GameOver();
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
