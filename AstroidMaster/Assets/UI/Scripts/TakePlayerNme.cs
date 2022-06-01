using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TakePlayerNme : MonoBehaviour
{
    public TMP_Text player;

    // Set Playername in the scence
    void Awake()
    {
        player.text = SendName.a.playerName;
    }
}
