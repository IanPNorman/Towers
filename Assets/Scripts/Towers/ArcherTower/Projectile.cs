using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8.5f;
    public float radius = 1f; 
    float radiusSq; 
    Transform target; 

    void OnEnable()
    {
        radiusSq = radius * radius;
    }

    void Update()
    {
        if (!target)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

        if (direction.sqrMagnitude < radiusSq)
        {
            Destroy(gameObject);
        }
    }

    public static Projectile Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform target)
    {
        GameObject go = Instantiate(prefab, position, rotation);
        Projectile p = go.GetComponent<Projectile>();
        if (!p) p = go.AddComponent<Projectile>();

        p.target = target;
        return p;
    }
}
