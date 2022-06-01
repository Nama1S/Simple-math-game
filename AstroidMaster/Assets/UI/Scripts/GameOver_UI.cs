using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_UI : MonoBehaviour
{
    //Exit the Game
    public void Exit_Game()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    
    //Directs to Main menu
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
    
    //Directs to scoreboard
    public void SendToScoreboard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}

