using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactuable : MonoBehaviour
{

    public Dialogo dialogo;

    public void trigger()
    {

        FindObjectOfType<DialogoManager>().EmpezarDialogo(dialogo);

    }

}
