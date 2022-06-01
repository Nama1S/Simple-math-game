using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;

public class ScoreBoard_Menu_Panel : MonoBehaviour
{
    public TMP_Text PlayerName;
    public TMP_Text EasyScore;
    public TMP_Text MediumScore;
    public TMP_Text HardScore;

    void Start()
    {
        StartCoroutine(GetScores(PlayerName.text, "Easy", EasyScore));
        StartCoroutine(GetScores(PlayerName.text, "Medium", MediumScore));
        StartCoroutine(GetScores(PlayerName.text, "Hard", HardScore));
    }

    //Get data trom database
    IEnumerator GetScores(string username, string level, TMP_Text Scorelevel)
    {
        WWWForm form = new WWWForm();
        form.AddField("User", username);
        form.AddField("Level", level);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Game/GetScore.php", form))
        {
            string Score;
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Score=www.downloadHandler.text;
                Scorelevel.text = Score;
            }
        }
    }

    //Directs to main menu
    public void GoMainMenuFromScoreBoard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }

    //Exit the game
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
