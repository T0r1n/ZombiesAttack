using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Statistic : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textDif;
    public TextMeshProUGUI textTime;
    
    private int sec = 0;
    public int score = 0;
    public float spawnInterval = 2f;

    public TextMeshProUGUI EndScore;

    public TextMeshProUGUI EndTime;

    public Animator endScreen;
    
    private void Start() {
        endScreen.updateMode = AnimatorUpdateMode.UnscaledTime;
        StartCoroutine(Timer());
    }
    

    void Update()
    {
        if (spawnInterval <= 1.4f){
            textDif.text = "Hard";
            textDif.color = Color.red;
        }
        else if (spawnInterval <= 1.7f){
            textDif.text = "Normal";
            textDif.color = Color.yellow;
        }
        else if(spawnInterval <= 2f){
            textDif.text = "Easy";
            textDif.color = Color.green;
        }
        textScore.text = score.ToString();
        textTime.text = sec.ToString();
    }

    IEnumerator Timer(){
        while(true){
            sec+=1;
            yield return new WaitForSeconds(1);
        }
    }

    public void EndGame(){
        EndScore.text = score.ToString();
        EndTime.text = sec.ToString();
        GameData.Record(sec,score);
        endScreen.SetTrigger("EndGame");
    }
}

    
