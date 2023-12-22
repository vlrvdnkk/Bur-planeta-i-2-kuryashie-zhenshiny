using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitMenuButton : MonoBehaviour
{
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
