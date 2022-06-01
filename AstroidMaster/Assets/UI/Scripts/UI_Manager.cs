using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    //Exit application
    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    //Directs to  Main menu from Game Over
    public void GoMainMenuFromGameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
}

