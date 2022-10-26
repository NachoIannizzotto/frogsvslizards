using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victoria : MonoBehaviour
{
    public string menuSceneName = "Menu";

    public string nextLevel = "Menu";
    //public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public void Continuar ()
    {
        //PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu ()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
