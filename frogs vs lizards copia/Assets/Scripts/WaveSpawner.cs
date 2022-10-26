using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]

    public class Wave
    {
        public string name;

        public Enemy[] enemies;
    }
    [System.Serializable]

    public class Enemy
    {
        public Transform enemyTransform;

        public int count;

        public float rate;
    }

    public Wave[] waves;

    private int nextWave = 0;

    public float timeBetweenWaves = 5f;

    public float waveCountdown;

    private float searchTimer = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public Text oleadaCountdownText;

    public GameObject VictoriaUI;

    //public GameManager gameManager;

    void Start()
    {
        //waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        waveCountdown -= Time.deltaTime;

        waveCountdown = Mathf.Clamp(waveCountdown, 0f, Mathf.Infinity);

        oleadaCountdownText.text = String.Format("{0:00.00}", waveCountdown);

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                beginNewRound();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
    }

    void beginNewRound()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Complete all waves");
            //gameManager.WinLevel();
            VictoriaUI.SetActive(true);
            this.enabled = false;
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchTimer -= Time.deltaTime;
        if (searchTimer <= 0f)
        {

            searchTimer = 1;

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {

        Stats.Oleadas++;

        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.enemies.Length; i++)
        {
            var temp = _wave.enemies[i];
            for (int j = 0; j < temp.count; j++)
            {
                SpawnEnemy(temp.enemyTransform);
                yield return new WaitForSeconds(1f / temp.rate);
            }
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Spawning Enemy: " + _enemy.name);
    }

}