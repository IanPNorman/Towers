using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ArcherIdle : ArcherState
{
    public bool canSeeEnemy;
    public ArcherState ArcherAttack;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            canSeeEnemy = true;
        }
    }
}

