using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    public string mainMenuLavel;

    public GameObject pauseMenu;

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(mainMenuLavel);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FindObjectOfType<GameManager>().Reset();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
