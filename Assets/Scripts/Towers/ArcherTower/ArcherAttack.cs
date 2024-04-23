using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class ArcherAttack : ArcherState
{
    [SerializeField] private bool cantSeeEnemy;
    [SerializeField] private ArcherState ArcherIdle;
    [SerializeField] private List<TestEnemy> targets = new List<TestEnemy>();
    [SerializeField] private GameObject currentTarget;
    [SerializeField] private GameObject Enemy;

    [SerializeField] private GameObject ArrowShooter;

    [SerializeField] private GameObject Arrow;
    [SerializeField] private Quaternion rotation;

    [SerializeField] private bool startedshooting = false;

    Projectile shoot;

    private IEnumerator coroutine;

    void Awake()
    {
        coroutine = Shooting();
        GameObject proj = new GameObject();
        shoot = proj.AddComponent<Projectile>();
    }

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
            if (currentTarget != null)
            {
                if (startedshooting == false) {
                    StartCoroutine(coroutine);
                    startedshooting = true;
                }
            }
            else
            {
                StopCoroutine(coroutine);
            }

  
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

    private IEnumerator Shooting()
    {
        while (true)
        {
            Projectile.Spawn(Arrow, ArrowShooter.transform.position, rotation, currentTarget.transform);
            yield return new WaitForSeconds(4f);
        }

    }



}

