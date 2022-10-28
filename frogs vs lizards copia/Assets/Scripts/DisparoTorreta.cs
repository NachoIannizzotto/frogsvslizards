using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using EZCameraShake;



public class DisparoTorreta : MonoBehaviour
{
    //VARIABLES//
    //Disparo y daño//
    public float damage;
    public float range = 300f;
    public float nextshotRate = 0f;
    public float shotRateTime;
    public Camera turretCam;
    public Vector3 raycastHits;


    //Munición y recarga//
    public int maxAmmo;
    public static int currentAmmo;
    public float reloadTime;


    //Efectos//
    public VisualEffect MuzzleL;
    public VisualEffect MuzzleR;
    public bool Muzzling = false;
    public GameObject waterImpactVFX;
    public GameObject woodImpactVFX;
    public GameObject bloodImpactVFX;
    
    
    //Trazado de balas//
        public Transform gunBarrellL;
        public Transform gunBarrellR;
        public TrailRenderer bulletTrail;
        public TrailRenderer BulletTrailSuper;
    
    //MetodosLlamados//
    public AbilitySystem abilitySystem;
    
    //SONIDO//
    private AudioSource audioSource;     
    public AudioClip DisparoTorretaHeroe;

    public void Awake()
    {
        
        currentAmmo = maxAmmo;
    }

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        abilitySystem = FindObjectOfType<AbilitySystem>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextshotRate)
        {
            nextshotRate = Time.time + 1f / shotRateTime;
            tryShot();
            audioSource.PlayOneShot(DisparoTorretaHeroe);
            //Shoot();//
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }
    

    void Shoot()
    {
        if (abilitySystem.effects==false)
        {
            var bulletL = Instantiate(bulletTrail, gunBarrellL.position, Quaternion.identity);
            bulletL.AddPosition(gunBarrellL.position);
            {
                bulletL.transform.position = transform.position + (turretCam.transform.forward * 200);
            }
            var bulletR = Instantiate(bulletTrail, gunBarrellR.position, Quaternion.identity);
            bulletR.AddPosition(gunBarrellR.position);
            {
                bulletR.transform.position = transform.position + (turretCam.transform.forward * 200);
            }
        }
        if(abilitySystem.effects==true)
        {
            var bulletL = Instantiate(BulletTrailSuper, gunBarrellL.position, Quaternion.identity);
            bulletL.AddPosition(gunBarrellL.position);
            {
                bulletL.transform.position = transform.position + (turretCam.transform.forward * 200);
            }
            var bulletR = Instantiate(BulletTrailSuper, gunBarrellR.position, Quaternion.identity);
            bulletR.AddPosition(gunBarrellR.position);
            {
                bulletR.transform.position = transform.position + (turretCam.transform.forward * 200);
            }
        }
        
        RaycastHit hit;
        if (Physics.Raycast(turretCam.transform.position, turretCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            raycastHits = hit.point;

            Enemy Enemy = hit.transform.GetComponent<Enemy>();
            if (Enemy != null)
            {
                Enemy.TakeDamage(damage);
            }
            PlayScript PlayScript = hit.transform.GetComponent<PlayScript>();
            if (PlayScript != null)
            {
                PlayScript.startgame();
            }
            //IMPACTOS
            Water Water = hit.transform.GetComponent<Water>();
            if (Water != null)
            {
                GameObject waterImpact = Instantiate(waterImpactVFX, hit.point, Quaternion.LookRotation(hit.point));
                Destroy(waterImpact, 2f);
            }
            Wood Wood = hit.transform.GetComponent<Wood>();
            if (Wood != null)
            {
                GameObject woodImpact = Instantiate(woodImpactVFX, hit.point, Quaternion.LookRotation(hit.point));
                Destroy(woodImpactVFX, 2f);
            }
            Blood Blood = hit.transform.GetComponent<Blood>();
            if (Blood != null)
            {
                GameObject bloodImpact = Instantiate(bloodImpactVFX, hit.point, Quaternion.LookRotation(hit.point));
                Destroy(bloodImpactVFX, 1f);
            }
        }
        Muzzling = !Muzzling;
        Muzzle();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(turretCam.transform.position, raycastHits);
    }
    
    //RECARGA//
    //Comprobando si hay municion//
    public bool tryShot()
    {
        if (currentAmmo>=1)
        {
            Shoot();
            currentAmmo -= 1;
            CameraShaker.Instance.ShakeOnce(2f, 6f, 0.5f, 0.5f);
            return true;
        }

        return false;
    }

    void Muzzle()
    {
        if (Muzzling)
        {
            MuzzleL.Play();
        }
        else
        {
            MuzzleR.Play();
        }
    }

    //Retardo para la recarga//
    IEnumerator Reload()
    {
        Debug.Log("Recargando.....");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        Debug.Log("Recarga Finalizada");
    }
}

