using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemySlime : Enemy
{
    private float speed = 10.0f;
    private int health = 10;
    private int money = 100;

    // still have no idea if this should be used
    //private Object materials = null;

    public EnemySlime()
    {
        this.speed = 10.0f;
        this.health = 10;
        this.money = 100;
    //    this.materials = null;
    }

    public EnemySlime(int multiplier)
    {
        this.speed = 10.0f;
        this.health = 10 * multiplier;
        this.money = 100 * multiplier;
     //   this.materials = null;
    }
}