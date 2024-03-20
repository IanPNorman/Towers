using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private Transform enemy;
    private float timeBetweenNextWave;
    private float countdown = 5f;



    // Start is called before the first frame update
    void Start()
    {
        if (countdown < 0f)
        {
            countdown = timeBetweenNextWave;
            SpawnWave();
        }
        countdown -= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnWave()
    {

    }
}
