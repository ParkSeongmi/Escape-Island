using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string sceneName = "GameScene";

    public void ClickStart()
    {
        Debug.Log("Loading");
        SceneManager.LoadScene(sceneName);
    }

    public void ClickLoad()
    {
        Debug.Log("Load");
    }

    public void ClickExit()
    {
        Debug.Log("End Game");
        Application.Quit();
    }
   
}
