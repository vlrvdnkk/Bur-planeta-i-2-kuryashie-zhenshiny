using System.Collections;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private MenuTrigger menuTrigger;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void GameOver()
    {
        anim.SetBool("IsOn", true);
        StartCoroutine(WaitForAnimation());
    }

    private IEnumerator WaitForAnimation()
    {
        menuTrigger.EnableScripts(false);
        yield return new WaitForSeconds((anim.GetCurrentAnimatorStateInfo(0).length) + 0.5f);
        Time.timeScale = 0;
    }
}
