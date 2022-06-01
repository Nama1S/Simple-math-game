using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_UI_Manager : MonoBehaviour
{
    //Directs to easy game scene
    public void Direct_EasyGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Directs to medium game scene
    public void Direct_MediumGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    //Directs to hard game scene
    public void Direct_HardGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    //Directs to Scoreboard
    public void Direct_ScoreBoard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    //Exit the game
    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
