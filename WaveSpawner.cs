using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmeraldAI.Utility;
using EmeraldAI;
using EmeraldAI.Example;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance;
    [Header("Wave Stats")]
    public Wave[] waves;

    public int waveNumber;

    private Wave currentWave;

    [Header("Wave Spawnpoints")]

    [SerializeField]
    private Transform[] spawnpoints;

    private float timeBtwnSpawns;
    private int i = 0;

    private bool stopSpawning = false;
    [Header("Wave UI/Links")]
    public OnDeath gameManager;

    public int enemiesAlive = 0;

    public Text roundNum;
    public Text roundsSurvived;
    public GameObject endScreen;

    private void Awake()
    {
        instance = this;
        //Calculates current wave
        currentWave = waves[i];
        timeBtwnSpawns = currentWave.TimeBeforeThisWave;
    }

    private void Update()
    {
        SpawnManager();
    }

    void SpawnManager()
    {
        // if stopspawning is true it will summon next wave unless there is no wave set after the previous one
        if (stopSpawning)
        {
            return;
        }

        if (Time.time >= timeBtwnSpawns && enemiesAlive == 0)
        {
            SpawnWave();
            IncWave();
            // posts the current wave on screen for the player.
            roundNum.text = "Round: " + waveNumber.ToString();
            timeBtwnSpawns = Time.time + currentWave.TimeBeforeThisWave;
        }
    }

    private void SpawnWave()
    {
        // Calculates the number of enemies to spawn (this is set in the Wave scriptable object)
        for (int i = 0; i < currentWave.NumberToSpawn; i++)
        {
            int num = Random.Range(0, currentWave.EnemiesInWave.Length);
            int num2 = Random.Range(0, spawnpoints.Length);

            Instantiate(currentWave.EnemiesInWave[num], spawnpoints[num2].position, spawnpoints[num2].rotation);
            currentWave.EnemiesInWave[num].GetComponent<OnDeath>().waveSpawner = GetComponent<WaveSpawner>();
            
            enemiesAlive++;
        }
    }

    public void EnemyDeath()
    {
        enemiesAlive--;
    }
    private void IncWave()
    {
        if (i + 1 < waves.Length)
        {
            i++;
            currentWave = waves[i];
            waveNumber++;
        }
        else
        {
            stopSpawning = true;
        }
    }
}

