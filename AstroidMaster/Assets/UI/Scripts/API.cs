using System.Collections;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.Networking;

public class API : MonoBehaviour
{
    #region Singleton class: DateTimeAPI

    public static API Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    #endregion

    //json container
    struct TimeData
    {
        public string datetime;
    }

    [HideInInspector] public bool IsTimeLoaded = false;

    private DateTime DateTimeNow = DateTime.Now;

    void Start()
    {
        StartCoroutine(GetRealDateTimeFromAPI());
    }

    public DateTime GetCurrentDateTime()
    {
        // Add elapsed time since the game start to DateTimeNow
        return DateTimeNow.AddSeconds(Time.realtimeSinceStartup);
    }

    IEnumerator GetRealDateTimeFromAPI()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get("https://worldtimeapi.org/api/ip");
        yield return webRequest.SendWebRequest();
        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            //error
            Debug.Log("Error: " + webRequest.error);
        }
        else
        {
            TimeData timeData = JsonUtility.FromJson<TimeData>(webRequest.downloadHandler.text);
            DateTimeNow = ParseDateTime(timeData.datetime);
            IsTimeLoaded = true;
        }
    }

    DateTime ParseDateTime(string datetime)
    {
        string date = Regex.Match(datetime, @"^\d{4}-\d{2}-\d{2}").Value;
        string time = Regex.Match(datetime, @"\d{2}:\d{2}:\d{2}").Value;

        return DateTime.Parse(string.Format("{0} {1}", date, time));
    }

}

/*API (json)

{
"abbreviation":"+0530",
"client_ip":"103.21.164.162",
"datetime":"2022-04-04T23:24:12.843836+05:30",
"day_of_week":1,
"day_of_year":94,
"dst":false,
"dst_from":null,
"dst_offset":0,
"dst_until":null,
"raw_offset":19800,
"timezone":"Asia/Colombo",
"unixtime":1649094852,
"utc_datetime":"2022-04-04T17:54:12.843836+00:00",
"utc_offset":"+05:30",
"week_number":14
}
*/
