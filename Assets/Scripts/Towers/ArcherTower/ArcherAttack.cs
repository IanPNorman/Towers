using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : ArcherState
{
    [SerializeField] private bool cantSeeEnemy;
    [SerializeField] private ArcherState ArcherIdle;
    [SerializeField] private List<TestEnemy> targets = new List<TestEnemy>();
    [SerializeField] private GameObject currentTarget;
    [SerializeField] private GameObject Enemy;



    public override ArcherState RunCurrentState()
    {
        if (cantSeeEnemy)
        {
            cantSeeEnemy = false;
            return ArcherIdle;
        }
        else
        {
            GetGurrentTarget();     
            return this;
        }
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("enemy"))
        {
            TestEnemy newEnemy = collision.GetComponent<TestEnemy>();
            targets.Add(newEnemy);
        }
    }


    void OnTriggerExit(Collider collision)
    {
        
        if (collision.CompareTag("enemy"))
        {
            TestEnemy enemy = collision.GetComponent<TestEnemy>();
            if (targets.Contains(enemy))
            {
                targets.Remove(enemy);  
            }
        }
    }

    void GetGurrentTarget()
    {
        if (targets.Count <= 0)
        {
            currentTarget = null;
            cantSeeEnemy = true;
            return;

        }
        currentTarget = targets[0].gameObject;
    }
}

