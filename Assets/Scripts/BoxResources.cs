using System.Collections.Generic;
using UnityEngine;

public class BoxResources : MonoBehaviour
{
    public GameObject boxObject;
    private List<GameObject> storedObjects = new List<GameObject>();  // List of stored objects
    private ItemCountDisplay itemCountDisplay; // Reference to itemCountDisplay

    private void Start()
    {
        // Get the ItemCountDisplay script component
        itemCountDisplay = FindObjectOfType<ItemCountDisplay>();

        if (itemCountDisplay == null)
        {
            Debug.LogWarning("ItemCountDisplay script not found in the scene.");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetItem();
        }
    }
    public void StoreItem(GameObject item)
    {
        storedObjects.Add(item);
        item.SetActive(false);
    }

    public void GetItem()
    {
        if (storedObjects.Count > 0)
        {
            // Get the most recently spawned object (last one in the list)
            GameObject objectToGet = storedObjects[storedObjects.Count - 1];
            storedObjects.Remove(objectToGet); // Remove the object from the list
            itemCountDisplay.decrementItemCount();

            // Get reference to main camera
            Camera mainCamera = Camera.main; 

            // Spawn position of stored object, slightly in front of main camera
            Vector3 spawnPos = mainCamera.transform.position + mainCamera.transform.forward * 2f;

            // Spawn the stored object at the given pos/rotation
            objectToGet.transform.position = spawnPos;

            // Make it active again
            objectToGet.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No stored objects to get.");
        }
    }
}
