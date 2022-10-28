using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCosas : MonoBehaviour
{
    public bool TiendaActivada = false;
    public bool TorretaActivada;
    public bool MunicionActivada;
    [SerializeField] GameObject _tienda;
    [SerializeField] GameObject _torreta;
    [SerializeField] GameObject _municion;
    public bool modo = true;
    void Start()
    {
        MunicionActivada = false;
        _municion.SetActive(false);
        TorretaActivada = false;
        _torreta.SetActive(false);

    }

    public void toggleMode()
    {
        if (modo == false)
        {
            modo = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        {
            modo = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
    }
    public void toggleMouse()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void activarTienda()
    {
        if (TiendaActivada == false)
        {
            _tienda.SetActive(false);
            TiendaActivada = true;
        }
        else
        {
            _tienda.SetActive(true);
            TiendaActivada = false;
        }
        Debug.Log(TiendaActivada);
    }
    public void activarTorreta()
    {
        if (TorretaActivada == true)
        {
            _torreta.SetActive(false);
            TorretaActivada = false;
        }
       else
        {
            _torreta.SetActive(true);
            TorretaActivada = true;
        }
        Debug.Log(TorretaActivada);
    }
    public void activarMunicion()
    {
        if (MunicionActivada == true)
        {
            _municion.SetActive(false);
            MunicionActivada = false;
        }
        else
        {
            _municion.SetActive(true);
            MunicionActivada = true;
        }
        Debug.Log(MunicionActivada);
    }
}
