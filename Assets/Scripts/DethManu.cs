using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethManu : MonoBehaviour
{
    public string mainMenuLavel;

    public void QuitToMainMenu()
    {
        Application.LoadLevel(mainMenuLavel);
    }

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }
}
