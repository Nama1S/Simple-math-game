using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking;

public class GameFunctionHard : MonoBehaviour
{
    int firstValue, secondValue, fourthValue, thirdValue, tempValue, finalAnswer;
    private int Answer1, Answer2, Answer3, score = 0;
    public TMP_Text FirstValue, SecondValue, ThirdValue, FourthValue, Ans_1, Ans_2, Ans_3, Ans_4, Answer_Space, TotalScore, Message;
    private float currentTime = 0f;
    private float startingTime=15;
    public TMP_Text Player;
    string level = "Hard";

    [SerializeField]
    TMP_Text datetimeText;

    [SerializeField]
    TMP_Text countDownText;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        CalculateFunction();
        if (API.Instance.IsTimeLoaded)
        {
            System.DateTime currentDateTime = API.Instance.GetCurrentDateTime();
            datetimeText.text = currentDateTime.ToString();
        }
    }

    // Update is called once per frame
    public void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            Message.text = "Time Over.";
            currentTime = 0;
            StartCoroutine(GameOver());
        }

        if (Input.GetMouseButtonUp(0) && API.Instance.IsTimeLoaded)
        {
            System.DateTime currentDateTime = API.Instance.GetCurrentDateTime();
            datetimeText.text = currentDateTime.ToString();
        }
    }

    //Generate Question and answers
    private void CalculateFunction()
    {
        PrintMessage();

        currentTime = startingTime;
        Answer_Space.text = "?";

        firstValue = Random.Range(1, 100);
        secondValue = Random.Range(1, 100);
        fourthValue = Random.Range(1, 100);
        thirdValue = Random.Range(1, 100);

        finalAnswer = firstValue + secondValue;

        FirstValue.text = firstValue.ToString();
        SecondValue.text = secondValue.ToString();
        FourthValue.text = fourthValue.ToString();
        ThirdValue.text = thirdValue.ToString();

        if (TotalScore.text == "")
        {
            TotalScore.text = "0";
        }

        //First Alternative
        tempValue = Random.Range(0, 400);
        while (tempValue == finalAnswer)
        {
            tempValue = Random.Range(0, 400);
        }
        Answer1 = tempValue;

        //Second Alternative
        tempValue = Random.Range(0, 400);
        while ((tempValue == finalAnswer) || (tempValue == Answer1))
        {
            tempValue = Random.Range(0, 400);
        }
        Answer2 = tempValue;

        //Third Alternative
        tempValue = Random.Range(0, 400);
        while ((tempValue == finalAnswer) || (tempValue == Answer1))
        {
            tempValue = Random.Range(0, 400);
        }
        Answer3 = tempValue;

        //Answer alternatives 
        tempValue = Random.Range(1, 9);
        if (tempValue == 1)
        {
            Ans_1.text = finalAnswer.ToString();
            Ans_2.text = Answer1.ToString();
            Ans_3.text = Answer2.ToString();
            Ans_4.text = Answer3.ToString();
        }
        if (tempValue == 2)
        {
            Ans_1.text = finalAnswer.ToString();
            Ans_2.text = Answer2.ToString();
            Ans_3.text = Answer1.ToString();
            Ans_4.text = Answer3.ToString();
        }
        if (tempValue == 3)
        {
            Ans_1.text = Answer1.ToString();
            Ans_2.text = finalAnswer.ToString();
            Ans_3.text = Answer2.ToString();
            Ans_4.text = Answer3.ToString();
        }
        if (tempValue == 4)
        {
            Ans_1.text = Answer1.ToString();
            Ans_2.text = Answer2.ToString();
            Ans_3.text = finalAnswer.ToString();
            Ans_4.text = Answer3.ToString();
        }
        if (tempValue == 5)
        {
            Ans_1.text = Answer2.ToString();
            Ans_2.text = finalAnswer.ToString();
            Ans_3.text = Answer1.ToString();
            Ans_4.text = Answer3.ToString();
        }
        if (tempValue == 6)
        {
            Ans_1.text = Answer2.ToString();
            Ans_2.text = Answer1.ToString();
            Ans_3.text = finalAnswer.ToString();
            Ans_4.text = Answer3.ToString();
        }
        if (tempValue == 7)
        {
            Ans_1.text = Answer2.ToString();
            Ans_2.text = Answer1.ToString();
            Ans_3.text = Answer3.ToString();
            Ans_4.text = finalAnswer.ToString();
        }
        if (tempValue == 8)
        {
            Ans_1.text = Answer2.ToString();
            Ans_2.text = Answer3.ToString();
            Ans_3.text = Answer1.ToString();
            Ans_4.text = finalAnswer.ToString();
        }
    }

    private void Ans_1_action()
    {
        ButtonAction(Ans_1.text);
    }
    private void Ans_2_action()
    {
        ButtonAction(Ans_2.text);
    }
    private void Ans_3_action()
    {
        ButtonAction(Ans_3.text);
    }
    private void Ans_4_action()
    {
        ButtonAction(Ans_4.text);
    }

    //ButtonAction
    private void ButtonAction(string answer)
    {
        string Answer = answer;
        if (Answer == finalAnswer.ToString())
        {
            PrintMessage("CORRECT");
            Right();
        }
        else
        {
            PrintMessage("WRONG");
            Wrong();
        }
    }

    //if answer is wrong, call game over method
    private void Wrong()
    {
        StartCoroutine(GameOver());
    }

    //if answer is wrong, generate next question
    private void Right()
    {
        Answer_Space.text = finalAnswer.ToString();
        StartCoroutine(NextQuestion());
        Score += 1;
        TotalScore.text = Score.ToString();
    }

    //Print message
    private void PrintMessage()
    {
        Message.text = "";
    }

    //Overload print message
    private void PrintMessage(string state)
    {
        Message.text = "ANSWER IS " + state;
    }

    //load next question
    private IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(1);
        CalculateFunction();
    }

    //Directs to Game over scene
    public IEnumerator GameOver()
    {
        StartCoroutine(SetScore(Player.text, level, datetimeText.text, System.Int32.Parse(TotalScore.text)));
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitButton()
    {
        StartCoroutine(GameOver());
    }

    //Save Score in database
    IEnumerator SetScore(string username, string level, string datetime, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("User", username);
        form.AddField("Level", level);
        form.AddField("DateTime", datetime);
        form.AddField("Score", score);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Game/SetScore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error");
            }
        }
    }
}