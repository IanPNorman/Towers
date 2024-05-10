using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class ArcherAttack : ArcherState
{
    [SerializeField] private bool cantSeeEnemy;
    [SerializeField] private ArcherState ArcherIdle;
    [SerializeField] private List<EnemyController> targets = new List<EnemyController>();
    [SerializeField] private GameObject currentTarget;
    [SerializeField] private GameObject Enemy;

    [SerializeField] private GameObject ArrowShooter;

    [SerializeField] private GameObject Arrow;

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
            startedshooting = false; 
            cantSeeEnemy = false;
            return ArcherIdle;
        }
        else
        {
            GetCurrentTarget();
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
            EnemyController newEnemy = collision.GetComponent<EnemyController>();
            targets.Add(newEnemy);
        }
    }


    void OnTriggerExit(Collider collision)
    {   
        if (collision.CompareTag("enemy"))
        {
            EnemyController enemy = collision.GetComponent<EnemyController>();
            if (targets.Contains(enemy))
            {
                targets.Remove(enemy);  
            }
        }
    }

    void GetCurrentTarget()
    {
        targets.RemoveAll(item => item == null || item.gameObject == null);
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
            if (currentTarget == null)
            {
                yield break;
            }
            Projectile.Spawn(Arrow, ArrowShooter.transform.position, Quaternion.LookRotation(currentTarget.transform.position - transform.position), currentTarget.transform);
            yield return new WaitForSeconds(2f);
        }

    }



}

