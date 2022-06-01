using UnityEngine;
using System;
using TMPro;

public class Test_API : MonoBehaviour
{
  

    [SerializeField] 
    TMP_Text datetimeText;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && API.Instance.IsTimeLoaded)
        {
            DateTime currentDateTime = API.Instance.GetCurrentDateTime();
            datetimeText.text = currentDateTime.ToString();
        }
    }
    
    void Start()
    {
        if (API.Instance.IsTimeLoaded)
        {
            DateTime currentDateTime = API.Instance.GetCurrentDateTime();
            datetimeText.text = currentDateTime.ToString();
        }
    }

}

