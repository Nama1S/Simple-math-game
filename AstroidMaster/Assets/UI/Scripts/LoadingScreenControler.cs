using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScreenControler : MonoBehaviour
{
    public Transform LoadingProcess;
    [SerializeField]
    private float Amt;
    [SerializeField]
    private float speed;

    //update is called one per frame
    void Update()
    {
        
        if (Amt<100)
        {
            Amt += speed * Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        LoadingProcess.GetComponent<Image>().fillAmount = Amt / 100;
    }
}