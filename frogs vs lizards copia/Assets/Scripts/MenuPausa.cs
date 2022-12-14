using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPausa : MonoBehaviour
{
    public GameObject ui;

    public string menuSceneName = "Menu";

    public SceneFader sceneFader;

    public ActivarCosas activarCosas;

    public void Start()
    {
        activarCosas = FindObjectOfType<ActivarCosas>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && activarCosas.modo == false)
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
