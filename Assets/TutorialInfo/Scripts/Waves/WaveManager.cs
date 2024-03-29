using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static int numOfEnemiesAlive;

    public Transform spawnPoint;

    [SerializeField] protected float timeBetweenNextWave = 10f;

    [SerializeField] protected float countdown = 5f;

    public Wave[] waves;

    protected int waveNumber = 0;

    protected int waveIndex = 0;

    protected bool readyToCountdown = false;

    //    private Transform[] waveOneEnemyList = [new EnemySlime, new EnemySlime, EnemySlime];




    //// Start is called before the first frame update
    //void Start()
    //{
    //    if (countdown < 0f)
    //    {
    //        countdown = timeBetweenNextWave;
    //        SpawnWave();
    //    }

    //    countdown -= Time.deltaTime;
    //}

    // Update is called once per frame
    void Update()
    {

        if (waveIndex > waves.Length)
        {
            Debug.Log("no more waves");
            return;
        }
        //if (numOfEnemiesAlive > 0)
        //{
        //    return;
        //}

        if (countdown <= 0f)
        {
             waveIndex++;
             StartCoroutine(SpawnWave());
             countdown = timeBetweenNextWave;
        }
        countdown -= Time.deltaTime;
    }
        

    private IEnumerator SpawnWave()
    {
        Debug.Log("A wave has spawned");
        numOfEnemiesAlive = waves[waveIndex].enemies.Length;
        for (int i = 0; i < waves[waveIndex].enemies.Length; i++)
        {
            SpawnEnemy(waves[waveIndex].enemies[i]);
            yield return new WaitForSeconds(waves[waveIndex].spawnRate);
        }
    }

    int GetWaveNumber()
    {
        return waveIndex;
    }

    //void SetEnemyList(Transform[] enemyList)
    //{
    //    this.enemyList = enemyList;
    //}

    //void SpawnEnemy(Transform[] enemyList)
    //{
    //    Instantiate(EnemySlime, spawnPoint.position, spawnPoint.rotation)
    //}

    void SpawnEnemy(Enemy enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}