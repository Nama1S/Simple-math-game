using UnityEngine;
using TMPro;

public class SendName : MonoBehaviour
{
    public static SendName a;
    public TMP_Text Nametxt;
    public string playerName;

    private void Awake()
    {
        if(a == null)
        {
            a = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Set username inorder to send it to next scene
    public void SetName()
    {
        playerName = Nametxt.text;
    }
}
