using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float velocidadInicial = 10f;
    [HideInInspector]
    public float velocidad;

    public float vidaInicial = 100f;
    private float vida = 0f;

    public int value = 50;

    [Header("Unity Stuff")]
    public Image BarraVida;

    private bool EstaMuerto = false;


    void Start()
    {
        vida = vidaInicial;
        velocidad = velocidadInicial;
    }
    public void TakeDamage (float amount)
    {
        vida -= amount;

        BarraVida.fillAmount = vida / vidaInicial;

        if (vida <= 0f && !EstaMuerto)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        velocidad = velocidadInicial * (1f - pct);
    }

    void Die ()
    {
        EstaMuerto = true;

        Stats.Dinero += value;

        GeneradorOleada.EnemigoVivos--;

        Destroy(gameObject);
    }

}

