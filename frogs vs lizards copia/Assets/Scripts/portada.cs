using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portada : MonoBehaviour
{
    public string menuSceneName = "Menu";

    public SceneFader sceneFader;

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
