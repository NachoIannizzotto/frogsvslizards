using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public string levelToLoad = "SampleScene";

    public SceneFader sceneFader;

    public void startgame()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void leftGame()
    {
        Application.Quit();
    }
}
