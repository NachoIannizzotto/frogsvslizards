using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject VictoriaUI;

    void Start()
    {
        GameIsOver = false;
    }
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        //if(Input.GetKeyDown("e"))
        {
            //EndGame();
        }

        if (Stats.Vida <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }

    public void WinLevel ()
    {
        GameIsOver = true;

        VictoriaUI.SetActive(true);
    }
}
