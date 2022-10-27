using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GT2.Demo;
 
public class cameramanager : MonoBehaviour
{
     
    public GameObject[] Cameras;
     
    int currentCam;
    public BuildManager buildManager;
    public ActivarCosas activarCosas;
    public TurretController turretController;
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
        CambioCamara();
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
     
    public void toggleCam(){
        currentCam++;
        if(currentCam > Cameras.Length-1)
            currentCam = 0;
        setCam(currentCam);
    }

   public void CambioCamara()
    {
        if (Input.GetButtonDown("Jump"))
        {
            toggleCam();
            buildManager.DeseleccionarNode();
            activarCosas.activarTorreta();
            activarCosas.activarTienda();
            activarCosas.activarMunicion();
            activarCosas.toggleMouse();
            turretController.Idler();
        }
    }
}
