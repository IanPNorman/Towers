using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ArcherIdle : ArcherState
{
    [SerializeField] private bool canSeeEnemy;
    [SerializeField] private ArcherState ArcherAttack;

    public override ArcherState RunCurrentState()
    {
        if (canSeeEnemy)
        {
            canSeeEnemy = false;
            return ArcherAttack;
        }
        else
        {
            return this;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("enemy"))
        {
            canSeeEnemy = true;
        }
    }
}

