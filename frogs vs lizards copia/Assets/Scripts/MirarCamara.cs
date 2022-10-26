using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarCamara : MonoBehaviour
{
    [SerializeField]
    private GameObject ObjectThatLooks;
    [SerializeField]
    private GameObject ObjectToLook;

    private Vector3 ObjectToLookPosition;

    void Start()
    {
        ObjectToLook = GameObject.FindGameObjectWithTag("Mirar");
    }

    void FixedUpdate()
    {
        lookAtObject ();
    }

    private void lookAtObject()
    {
        ObjectToLookPosition = ObjectToLook.transform.position;
        ObjectThatLooks.transform.LookAt(ObjectToLookPosition);
    }
}
