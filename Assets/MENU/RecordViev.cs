using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordViev : MonoBehaviour
{
    public TextMeshProUGUI RScore;
    public TextMeshProUGUI RTime;
    void Start()
    {
        RScore.text = GameData.recordScore.ToString();
        RTime.text = GameData.recordTime.ToString() + " sec";
    }


}
