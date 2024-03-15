using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    private List<GameObject> spawnedObjects = new List<GameObject>(); // List to store references to spawned objects

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }

        // Example: Pressing the X key to destroy the most recently spawned object
        if (Input.GetKeyDown(KeyCode.X))
        {
            DestroyMostRecentSpawnedObject();
        }
    }

    void Spawn()
    {
        if (objectToSpawn != null && spawnPoint != null)
        {
            GameObject gameObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            spawnedObjects.Add(gameObject);
        }
        else
        {
            Debug.LogWarning("Spawnee or Spawn Point not assigned");
        }
    }

    void DestroyMostRecentSpawnedObject()
    {
        if (spawnedObjects.Count > 0)
        {
            // Get the most recently spawned object (last one in the list)
            GameObject objectToDestroy = spawnedObjects[spawnedObjects.Count - 1];
            spawnedObjects.Remove(objectToDestroy); // Remove the object from the list
            Destroy(objectToDestroy); // Destroy the object
        }
        else
        {
            Debug.LogWarning("No spawned objects to destroy.");
        }
    }
}
