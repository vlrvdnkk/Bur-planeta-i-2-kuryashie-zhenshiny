using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuTrigger : MonoBehaviour
{
    [SerializeField] private CannonShooting cannonShooting;
    [SerializeField] private RotationScript rotationScript;
    [SerializeField] private ShootPointScript shootPointScript;
    [SerializeField] private EventTrigger eventTrigger;
    [SerializeField] private Button toggleButton;
    [SerializeField] private float moveSpeed = 5f;
    private bool isMenuVisible = false;
    private Animator animator;

    void Start()
    {
        EnableScripts(false);
        toggleButton.interactable = false;
        animator = GetComponent<Animator>();
        toggleButton.onClick.AddListener(DownMenu);
    }

    public void UpMenu()
    {
        if (!isMenuVisible)
        {
            animator.SetInteger("State", 1);
            isMenuVisible = true;
            StartCoroutine(WaitForAnimation());
        }
    }

    public void DownMenu()
    {
        if (isMenuVisible)
        {
            Time.timeScale = 1;
            animator.SetInteger("State", 2);
            EnableScripts(true);
            toggleButton.interactable = false;
            isMenuVisible = false;
        }
    }

    public void EnableScripts(bool enable)
    {
        eventTrigger.enabled = enable;
        cannonShooting.enabled = enable;
        shootPointScript.enabled = enable;
        rotationScript.enabled = enable;
    }

    private IEnumerator WaitForAnimation()
    {
        EnableScripts(false);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        toggleButton.interactable = true;
        Time.timeScale = 0;
    }
}