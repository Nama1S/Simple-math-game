using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TakeUsername : MonoBehaviour
{
    public TMP_Text player;

    // Set username in the scence
    private void Awake()
    {
        player.text = Authantication.a.p.text;
    }
}
