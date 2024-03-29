using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public GameObject parentObject;
    public Collider boxCollider;
    public LayerMask targetLayers; // Layers of objects that trigger the event
    public List<GameObject> boxResources = new List<GameObject>();
    const int BoxLimit = 4;  // constant to determine how many objects the box can hold 

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " entered the box trigger.");
        if (boxResources.Count < BoxLimit)
        {
            if (((1 << other.gameObject.layer) & targetLayers) != 0)
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {  
                    boxResources.Add(other.gameObject);
                    Debug.Log("Current Item Count: " + boxResources.Count);

                    // Set collided object as child of the parent object 
                    other.gameObject.transform.SetParent(parentObject.transform);

                    // Get reference to resourceScript component. 
                    ResourceInBox resourceScript = other.gameObject.GetComponent<ResourceInBox>();

                    if (resourceScript != null)
                    {
                        resourceScript.enabled = true;
                    }
                    else
                    {
                        // Add script as a component of the new child object
                        other.gameObject.AddComponent<ResourceInBox>();

                        // Set some properties in the attached script
                        resourceScript.triggerObject = gameObject;
                        resourceScript.objectNumber = boxResources.Count;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Box is full!");
        }
    }

    public void removeResource(int objNumber)
    {
        if (boxResources.Count > 0)
        {
            // Get the most recently spawned object (last one in the list)
            GameObject objToRemove = boxResources[objNumber];
            boxResources.Remove(objToRemove); // Remove the object from the list
            objToRemove.transform.SetParent(null); // Detach child object 
        }
        else
        {
            Debug.LogWarning("Error. There is no object to remove.");
        }
    }

    private void OnDrawGizmos()
    { 
        Collider collider = GetComponent<Collider>();

        if (collider.isTrigger)
        {
            // Set the color and transparency of Gizmos
            Color gizmoColor = new Color(1f, 0f, 0f, 0.5f); // Red, 50% transparency
            Gizmos.color = gizmoColor;

            // Draw box using collider's bounds
            Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);
        }
    }
}

// Change layer of game object to "Hands", where it can only interact with xr hands.
// other.gameObject.layer = LayerMask.NameToLayer("Hands");
// other.excludeLayers = LayerMask.NameToLayer("Default"); 