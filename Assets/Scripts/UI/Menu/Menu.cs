using UnityEngine;

public class Menu : MonoBehaviour
{
    private void Awake()
    {
        ViewMenu(false);
    }

    public void GameManager(int status)
    {
        if(status == 0)
        {
            ViewMenu(true);
            Time.timeScale = status;
        }

        if(status == 1)
        {
            ViewMenu(false);
            Time.timeScale = status;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void ViewMenu(bool statusMenu)
    {
        gameObject.SetActive(statusMenu);
    }
}
