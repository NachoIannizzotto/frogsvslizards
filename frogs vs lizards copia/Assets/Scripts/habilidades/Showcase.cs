using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showcase : MonoBehaviour
{
    [SerializeField] int time;
    CanvasGroup canvasGroup;
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(Action());
        }
        if (Input.GetKeyUp(KeyCode.Tab)) 
        {
            StopCoroutine(Action());
            Time.timeScale = 1f;
            canvasGroup.alpha = 0;
        }
    }
    IEnumerator Action ()
    {
        yield return new WaitForSeconds(time);
        canvasGroup.alpha = 1;
        Time.timeScale = 0f;
    }
}
