using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarCamara : MonoBehaviour
{
    public GameObject Camara;
    void Update()
    {
        transform.LookAt(Camara.transform.position);
    }
}
