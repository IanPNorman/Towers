using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private GameObject waypointsContainer; 
    private Transform[] waypoints;
    private int waypointIndex = 0;
    private Transform target;

    void Start()
    {
        InitializeWaypoints();
        if (waypoints.Length > 0)
            target = waypoints[0];
    }

    void InitializeWaypoints()
    {
        // Assuming waypoints are all the direct children of the waypointsContainer GameObject
        if (waypointsContainer != null)
        {
            waypoints = new Transform[waypointsContainer.transform.childCount];
            for (int i = 0; i < waypointsContainer.transform.childCount; i++)
            {
                waypoints[i] = waypointsContainer.transform.GetChild(i);
            }
        }
    }

    void Update()
    {
        MoveTowardsGoal();
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= waypoints.Length - 1)
        {
            ReachEnd(); // Handle what happens when the enemy reaches the last waypoint
            return;
        }
        waypointIndex++;
        target = waypoints[waypointIndex];
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void ReachEnd()
    {
        // Implement what happens when the enemy reaches the end
        Destroy(gameObject);
    }

    public void Die()
    {
        // Optional: Add functionality for dropping items
        Destroy(gameObject);
    }

    private void MoveTowardsGoal()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            transform.position += direction.normalized * (speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }
        }
    }
}
