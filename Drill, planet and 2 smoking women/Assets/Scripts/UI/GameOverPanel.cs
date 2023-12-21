using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private MenuTrigger menuTrigger;
    [SerializeField] private GameObject panel;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void GameOver()
    {
        panel.SetActive(true);
        anim.SetBool("IsOn", true);
        StartCoroutine(WaitForAnimation());
    }

    private System.Collections.IEnumerator WaitForAnimation()
    {
        menuTrigger.EnableScripts(false);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Time.timeScale = 0;
    }
}
