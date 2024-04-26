using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int numOfEnemiesAlive = 1;

    public Transform spawnPoint;

    [SerializeField] protected float timeBetweenNextWave = 10f;

    [SerializeField] protected float countdown = 5f;

    public Wave[] waves;

    protected int waveNumber = 0;

    protected int waveIndex = 0;

    protected bool readyToCountdown = false;


    //    private Transform[] waveOneEnemyList = [new EnemySlime, new EnemySlime, EnemySlime];




    // Start is called before the first frame update
    void Start()
    {
        readyToCountdown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveIndex >= waves.Length)
        {
            Debug.Log(waveIndex + "this is waveIndex" + waves.Length + "this is waves.Length");
            return;
        }

        if (countdown <= 0f)
        {
            //readyToCountdown = false;
             StartCoroutine(SpawnWave());
             countdown = timeBetweenNextWave;
            return;
        }
        //if (numOfEnemiesAlive == 0)
        //{
        //    readyToCountdown=true;
        //    waveIndex++;
        //}
        if (readyToCountdown == true)
        {
            countdown -= Time.deltaTime;
        }
    }
        

    private IEnumerator SpawnWave()
    {
        if (waveIndex < waves.Length)
        {
            Debug.Log("A wave has spawned");
            numOfEnemiesAlive = waves[waveIndex].enemies.Length;
            Debug.Log(waves[waveIndex].enemies.Length);
            for (int i = 0; i < waves[waveIndex].enemies.Length; i++)
            {
                Debug.Log("i ran!");
                SpawnEnemy(waves[waveIndex].enemies[i]);

                yield return new WaitForSeconds(waves[waveIndex].spawnRate);
            }
            // disable this once numOfEnemiesAlive becomes usable
            waveIndex++; 
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

        //enemy.transform.SetParent(spawnPoint.transform);
    }

    //public static void decreaseNumOfEnemiesAlive()
    //{
    //    numOfEnemiesAlive--;
    //    Debug.Log("I ran");
    //}

    public int getWaveIndex()
    {
        return waveIndex;
    }
}