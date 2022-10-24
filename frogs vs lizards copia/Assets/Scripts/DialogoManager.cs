using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoManager: MonoBehaviour
{

    public TextMeshProUGUI TextoNombre;
    public TextMeshProUGUI TextoDialogo;

    public Queue<string> dialogos;

    public Animator animacion;

    public GameObject flechasTorretas;

    private void Start()
    {

        dialogos = new Queue<string>();

    }

    public void EmpezarDialogo(Dialogo dialogo)
    {

        animacion.SetBool("abierto", true);

        TextoNombre.text = dialogo.nombre;

        dialogos.Clear();

        foreach(string oracion in dialogo.oraciones)
        {

            dialogos.Enqueue(oracion);

        }

        MostrarSiguienteOracion();

        

    }

    public void MostrarSiguienteOracion()
    {
        if(dialogos.Count == 0)
        {

            TermirarConversacion();
            return;

        }

        string oracion = dialogos.Dequeue();

        if (oracion == "estas son las torretas")
        {
            flechasTorretas.SetActive(true);
        }
        else
        {
            flechasTorretas.SetActive(false);
        }
        StopAllCoroutines();
        StartCoroutine(TipoOracion(oracion));
    }

    IEnumerator TipoOracion (string oracion)
    {

        TextoDialogo.text = "";

        foreach(char letra in oracion.ToCharArray())
        {

            TextoDialogo.text += letra;
            yield return null;

        }

    }

    public void TermirarConversacion()
    {
        animacion.SetBool("abierto", false);

       
    }

}
