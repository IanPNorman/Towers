using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : ArcherState
{
    public bool cantSeeEnemy;
    public ArcherState ArcherIdle;

    public override ArcherState RunCurrentState()
    {
        if (cantSeeEnemy)
        {
            cantSeeEnemy = false;
            return ArcherIdle;
        }
        else
        {
            return this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            cantSeeEnemy = true;
        }
    }
}

