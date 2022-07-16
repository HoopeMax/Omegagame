using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string playGameLavel;
 
    public void PlayGame()
    {
        Application.LoadLevel(playGameLavel);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
