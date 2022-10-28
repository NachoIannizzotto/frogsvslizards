using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tienda : MonoBehaviour{

    public blueprintTorreta torretaStandar;
    public blueprintTorreta misiles;
    public blueprintTorreta RayoLaser;
    public blueprintTorreta HongoPlata;
    public Text coste1;
    public Text coste1mejora;
    public Text coste2;
    public Text coste2mejora;
    public Text coste3;
    public Text coste3mejora;
    public Text coste4;
    public Text coste4mejora;


    BuildManager buildManager;

    public void Awake()
    {
        buildManager = BuildManager.instancia;
        coste1.text = "$ " + torretaStandar.coste.ToString();
        coste1mejora.text = "$ " + torretaStandar.costeUpgrade.ToString();
        coste2.text ="$ " + misiles.coste.ToString();
        coste2mejora.text = "$ " + misiles.costeUpgrade.ToString();
        coste3.text = "$ " + RayoLaser.coste.ToString();
        coste3mejora.text = "$ " + RayoLaser.costeUpgrade.ToString();
        coste4.text = "$ " + HongoPlata.coste.ToString();
        coste4mejora.text = "$ " + HongoPlata.costeUpgrade.ToString();
    }
    private void Start()
    {

    }

    public void SeleccionarTorreta ()
    {
        Debug.Log("Torreta Comprada");
        buildManager.SeleccionarTorretaAConstruir(torretaStandar);
    }
    public void SeleccionarMisisles()
    {
        Debug.Log("Otra Torreta Comprada");
        buildManager.SeleccionarTorretaAConstruir(misiles);
    }

    public void SeleccionarRayoLaser()
    {
        Debug.Log("Otra Torreta mas Comprada");
        buildManager.SeleccionarTorretaAConstruir(RayoLaser);
    }

    public void SeleccionarHongoPlata()
    {
        Debug.Log("Otra Torreta mas Comprada");
        buildManager.SeleccionarTorretaAConstruir(HongoPlata);
    }
}
