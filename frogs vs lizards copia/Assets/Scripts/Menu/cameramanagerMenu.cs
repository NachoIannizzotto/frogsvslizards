using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GT2.Demo;
 
public class cameramanagerMenu : MonoBehaviour
{

    public GameObject[] Cameras;

    int currentCam;
    public BuildManager buildManager;
    public ActivarCosas activarCosas;
    public TurretController turretController;

    //Metodos Llamados//
    public PlayScript playScript;
    // Start is called before the first frame update
    void Start()
    {
        currentCam = 0;
        setCam(currentCam);
        buildManager = FindObjectOfType<BuildManager>();
        activarCosas = FindObjectOfType<ActivarCosas>();
        turretController = FindObjectOfType<TurretController>();
    }
 
    // Update is called once per frame
    void Update()
    {
        if (currentCam==0)
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

        }

        // if (playScript.levelToLoad=="SampleScene")
        // {
        //
        //     buildManager.DeseleccionarNode();
        //     activarCosas.activarTorreta();
        //     activarCosas.activarTienda();
        //     activarCosas.activarMunicion();
        //     activarCosas.toggleMouse();
        //     turretController.Idler();
        // }




    }

    public void setCam(int idx){
        for(int i = 0; i < Cameras.Length; i++){
            if(i == idx){
                Cameras[i].SetActive(true);
            }else{
                Cameras[i].SetActive(false);
            }
        }
    } 
}