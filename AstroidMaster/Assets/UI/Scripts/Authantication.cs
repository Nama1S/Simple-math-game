using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class Authantication : MonoBehaviour
{
    public TMP_InputField L_Username;
    public TMP_InputField L_Password;
    public TMP_Text L_message;

    public TMP_InputField R_Username;
    public TMP_InputField R_Password;
    public TMP_InputField R_ConfirmPassword;
    public TMP_Text R_message;
    string Auth;

    public static Authantication a;
    public string playerName;
    public TMP_Text p; 

    public void Loginbutton()
    {
        StartCoroutine(Loginn(L_Username.text, L_Password.text));
    }

    public void Registerbutton()
    {
        StartCoroutine(Register(R_Username.text, R_Password.text));
    }

    //User Login method
    IEnumerator Loginn(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Game/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                L_message.text = www.error;
            }
            else
            {
                Auth = www.downloadHandler.text;
            }
            Authe(Auth, L_message,username);
        }
    }

    //User register method
    IEnumerator Register(string username, string password)
    {
        if (R_Username.text == "")
        {
            R_message.text = "Enter a Username";
        }
        else if (R_Password.text != R_ConfirmPassword.text)
        {
            R_message.text = "Please confirm password";
        }
        else
        {
            WWWForm form = new WWWForm();
            form.AddField("loginUser", username);
            form.AddField("loginPass", password);

            using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Game/Register.php", form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    R_message.text = www.error; 
                }
                else
                {
                    Auth = www.downloadHandler.text;
                }
                Authe(Auth, R_message, username);
            }
        }
    }

    private void Authe(string auth, TMP_Text message,string User)
    {
        int x = System.Int32.Parse(auth);
        if (x == 1)
        {
            message.text = "WELCOME "+User;
            StartCoroutine(Play());
            SetName();
        }
        else if(x == 2)
        {
            message.text = "Enter Correct Password.";
        }
        else if(x == 3)
        {
            message.text = "Username does not exit, please register.";
        }
        else if(x == 4)
        {
            message.text = "Error. Please try again.";
        }
        else if(x == 5)
        {
            message.text = "Username Already taken.";
        }
    }

    public IEnumerator Play()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Awake()
    {
        if (a == null)
        {
            a = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SetName()
    {
        if(L_Username.text != "")
        {
            playerName = L_Username.text;
            p.text = playerName;
        }
        if (R_Username.text !="")
        {
            playerName = R_Username.text;
            p.text = playerName;
        }   
    }
}
