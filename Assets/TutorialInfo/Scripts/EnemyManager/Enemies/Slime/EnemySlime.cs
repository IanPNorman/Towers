using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemySlime : Enemy
{

    // still have no idea if this should be used
    //private Object materials = null;

    private void Start()
    {
        speed = 10f;
        health = 10;
        money = 100;
        target = Waypoint.points[0];
    }
    //private void Update()
    //{
    //    MoveTowardsGoal();
    //}
}