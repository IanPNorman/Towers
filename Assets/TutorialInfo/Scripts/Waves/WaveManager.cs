using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int numOfEnemiesAlive = 0;
    public Transform spawnPoint;
    public Wave[] waves;
    public float timeBetweenNextWave = 20f;
    public float countdown = 10f;

    private int waveIndex = 0;
    private bool isSpawning = false; 

   

    void Update()
    {
        
        if (waveIndex >= waves.Length)
        {
            return;
        }

        if (!isSpawning && numOfEnemiesAlive <= 0)
        {
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                
                countdown = timeBetweenNextWave; 
            }
            else
            {
                countdown -= Time.deltaTime;
            }
        }
    }

    private IEnumerator SpawnWave()
    {
        isSpawning = true; 
        Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            numOfEnemiesAlive++;
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }
        waveIndex++;
        isSpawning = false; 
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void OnEnemyDeath()
    {
        numOfEnemiesAlive--;
    }
}
