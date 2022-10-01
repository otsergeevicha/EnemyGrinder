using UnityEngine;

public class Menu : MonoBehaviour
{
    private void Awake()
    {
        ViewMenu(false);
    }

    public void Play(int value)
    {
        ViewMenu(false);
        Time.timeScale = value;
    }

    public void Pause(int value)
    {
        ViewMenu(true);
        Time.timeScale = value;
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
