using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 10.0f;
    [SerializeField] private GameObject waypointsContainer;
    [SerializeField] private GameObject endGoal;
    [SerializeField] private int health;

    [SerializeField] private WaveManager waveManager;

    private Transform[] waypoints;
    private int waypointIndex = 0;
    private Transform target;

    void Start()
    {
        health = 3;
        InitializeWaypoints();
        UpdateTarget();
    }

    void Update()
    {
        if(health <= 0)
        {
            killEnemy();
        }
        MoveToWaypoint();
        RotateTowardsTarget();
    }

    private void InitializeWaypoints()
    {
        waypoints = new Transform[waypointsContainer.transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointsContainer.transform.GetChild(i);
        }
    }

    private void UpdateTarget()
    {
        if (waypointIndex >= waypoints.Length)
        {
            target = endGoal.transform;
        }
        else
        {
            target = waypoints[waypointIndex];
        }
    }

    private void MoveToWaypoint()
    {
        Vector3 direction = target.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            waypointIndex++;
            if (waypointIndex > waypoints.Length)
            {

                target = endGoal.transform;
                if (Vector3.Distance(transform.position, target.position) < 0.1f)
                {
                    killEnemy();
                }
            }
            UpdateTarget();
        }
    }

    public void doDamage()
    {
        health--;
    }
    public void killEnemy()
    {
        waveManager.OnEnemyDeath();
        AudioManager.Instance.PlaySFX("Slime_Death");
        Destroy(gameObject);
    }

    private void RotateTowardsTarget()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
