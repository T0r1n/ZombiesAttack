using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public int sceneID;
    public void LoadSceneID(){
        SceneManager.LoadScene(sceneID);
        Time.timeScale = 1;
    }

    public void PressExit(){
        Application.Quit();
    }

    
}
