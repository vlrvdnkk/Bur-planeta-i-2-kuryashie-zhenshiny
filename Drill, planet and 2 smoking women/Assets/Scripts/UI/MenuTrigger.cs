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

            // ��������� ��������, ������� ������������� ����� ����� ������������ ��������
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
        // ����, ���� ������� �������� �� ����������
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // ����� ���������� �������� ��������� ��������, ������� ��� �����
        Time.timeScale = 0;
    }
}