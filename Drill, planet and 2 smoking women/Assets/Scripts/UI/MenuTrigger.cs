using UnityEngine;
using UnityEngine.UI;

public class MenuTrigger : MonoBehaviour
{
    [SerializeField] private RectTransform panelRect;
    [SerializeField] private Button toggleButton;
    [SerializeField] private float moveSpeed = 5f;
    private bool isMenuVisible = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        toggleButton.onClick.AddListener(DownMenu);
    }

    public void UpMenu()
    {
        if (!isMenuVisible)
        {
            animator.SetInteger("State", 1);
            isMenuVisible = true;

            // Запускаем корутину, которая останавливает время после проигрывания анимации
            StartCoroutine(WaitForAnimation());
        }
    }

    public void DownMenu()
    {
        if (isMenuVisible)
        {
            Time.timeScale = 1;
            animator.SetInteger("State", 2);
            isMenuVisible = false;
        }
    }

    private System.Collections.IEnumerator WaitForAnimation()
    {
        // Ждем, пока текущая анимация не завершится
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // После завершения анимации выполните действия, которые вам нужны
        Time.timeScale = 0;
    }
}