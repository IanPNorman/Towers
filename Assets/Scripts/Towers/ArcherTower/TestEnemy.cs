using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private TestEnemy enemy;
    void Start()
    {
       enemy =  GetComponent<TestEnemy>(); 
    }

    
    void Update()
    {
        
            _enemy.transform.Translate((Vector3.forward*5) * Time.deltaTime);
        
    }
}
