using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySystem : MonoBehaviour
{
    public bool habilitarAb = false;

    [Header("Ability 1")] //HABILIDAD 1
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;
    public DisparoTorreta disparoTorreta;
    public float time = 0.0f;
    public float loopDuration = 20.0f;

    [Header("Ability 2")] //HABILIDAD 2
    public Image abilityImage2;
    public float cooldown2 = 5;
    bool isCooldown2 = false;
    public KeyCode ability2;

    [Header("Ability 3")] //HABILIDAD 3
    public Image abilityImage3;
    public float cooldown3 = 5;
    bool isCooldown3 = false;
    public KeyCode ability3;

    [Header("Ability 4")] //POSIBLE HABILIDAD 4
    public Image abilityImage4;
    public float cooldown4 = 5;
    bool isCooldown4 = false;
    public KeyCode ability4;

    void Start() //INICIALIZA LOS VALORES DE LA IMAGEN EN 0.
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        abilityImage4.fillAmount = 0;
        disparoTorreta = FindObjectOfType<DisparoTorreta>();
    }

    void Update() //CADA FRAME SE LLAMA A LAS HABILIDADES EN EL CASO DE QUE HAYAN SIDO TRIGGEREADAS.
    {
        StartCoroutine(Ability1());
        Ability2();
        Ability3();
        Ability4();
    }


    IEnumerator Ability1() //FUNCIÓN HABILIDAD 1
    {
        if (Input.GetKey(ability1) && isCooldown == false && habilitarAb == true) //ADENTRO DE ESTE IF SE COLOCA LA HABILIDAD O REFERENCIA AL SCRIPT DE LA HABILIDAD 1. (CONTROLA SI SE HA PRESIONADO LA HABILIDAD)
        {
            isCooldown = true;
            abilityImage1.fillAmount = 1;
            do
            {
                disparoTorreta.shotRateTime = 15;
                Debug.Log("HABILIDAD1");
                time += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            } while (time < loopDuration);

            time = 0.0f;
            disparoTorreta.shotRateTime = 5;
            Debug.Log("HABILIDAD1 FINALIZADO");
        }

        if (isCooldown) //ESTE IF CONTROLA CUANDO INICIAR EL COOLDOWN.
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (abilityImage1.fillAmount <= 0) //ESTE IF CONTROLA CUANDO FINALIZA EL COOLDOWN Y REESTABLECE LA HABILIDAD.
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false && habilitarAb == true)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
        }

        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }
    void Ability3()
    {
        if (Input.GetKey(ability3) && isCooldown3 == false && habilitarAb == true)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
        }

        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }
    void Ability4()
    {
        if (Input.GetKey(ability4) && isCooldown4 == false && habilitarAb == true)
        {
            isCooldown4 = true;
            abilityImage4.fillAmount = 1;
        }

        if (isCooldown4)
        {
            abilityImage4.fillAmount -= 1 / cooldown4 * Time.deltaTime;

            if (abilityImage4.fillAmount <= 0)
            {
                abilityImage4.fillAmount = 0;
                isCooldown4 = false;
            }
        }
    }
}