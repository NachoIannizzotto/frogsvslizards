using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour{

    public static int Dinero;
    public int DineroInicial = 300;

    public static int Vida;
    public int VidaInicial = 30;

    public static int Oleadas;

    private void Start()
    {
        Dinero = DineroInicial;
        Vida = VidaInicial;

        Oleadas = 0;
    }

}
