using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public int CurHealth = 0;
    public int MaxHealth = 100;
    [SerializeField] private GameOverScript gameOverScript;
    private Slider healthBar;

    public void Start()
    {
        healthBar = GetComponent<Slider>();
        CurHealth = MaxHealth;
    }

    public void DamagePlayer(int damage)
    {
        CurHealth -= damage;
        healthBar.value = CurHealth;
        if (CurHealth <= 0)
        {
            gameOverScript.GameOver();
        }
    }
}
