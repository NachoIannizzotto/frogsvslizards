using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarCamara : MonoBehaviour
{
    public GameObject Camara;
    void Start()
    {
        //Camara = FindObjectOfType<MirarVida>();
        transform.LookAt(Camara.transform.position);
    }
}
