using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static int recordScore = 0;
    public static int recordTime = 0;

    public static void Record(int time, int score){
        if (time > recordTime){
            recordTime = time;
        }
        if (score > recordScore){
            recordScore = score;
        }
    }

}
