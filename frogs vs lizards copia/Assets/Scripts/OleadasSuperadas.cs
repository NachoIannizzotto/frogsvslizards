using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OleadasSuperadas : MonoBehaviour
{
    public Text OleadaSuperadasText;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText ()
    {
        OleadaSuperadasText.text = "0";
        int oleada = 0;

        yield return new WaitForSeconds(.7f);

        while (oleada < Stats.Oleadas)
        {
            oleada++;
            OleadaSuperadasText.text = oleada.ToString();

            yield return new WaitForSeconds(.05f);
        }
    }
}
