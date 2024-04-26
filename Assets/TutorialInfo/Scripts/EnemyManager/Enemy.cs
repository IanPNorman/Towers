using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float speed;
    protected int health;
    protected int money;
    protected int damage;
    protected Transform target;
    // bad
    protected int waypointIndex = -1;

    //private WaveManager waveManager;

 

    // not sure what the game plan is here
    // private GameObject materials;
    //public Enemy()
    //{

    //}

    //public Enemy(float speed, int health, int money, int damage/*, GameObject materials*/)
    //{
    //    this.speed = speed;
    //    this.health = health;
    //    this.damage = damage;
    //    this.money = money;
    //    //this.materials = materials;
    //}

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoint.points[0];
        Quaternion quaternion = Quaternion.identity;
        //waveManager = GetComponentInParent<WaveManager>();
    }

    void Update()
    {
        MoveTowardsGoal();
    }

    public void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoint.points.Length - 1)
        {
            // call lose lives
            Destroy(gameObject);

            //waveManager.numOfEnemiesAlive--;
            return;
        }
        waypointIndex++;
        target = Waypoint.points[waypointIndex];
    }

    // will finish with an observer function once fully integrated
    public void TakeDamage(int damage)
    {
        this.health -= damage;
        if (health < 0)
        {
            Die();
        }
    }

    public void DealDamage()
    {
        // pretty sure u have to check if the conditions for dealing damage is valid every tick or something like that
    }

    public void reachEnd()
    {
        // function for damaging base hp when reaching the end
    }

    public void Die()
    {
        DropObjects();
        //waveManager.numOfEnemiesAlive--;
        Destroy(gameObject);
    }

    public void DropObjects()
    {
        // do something where it would drop money or something like that
    }

    public void ModifySpeed(float modifier, float duration)
    {
        // i have no idea how to do this, probably a stretch goal
    }

    public void MoveTowardsGoal()
    {
        //Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
        //transform.rotation = rotation;
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * (speed * Time.deltaTime));

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    //public void SetRotation()
    //{

    //}
}
