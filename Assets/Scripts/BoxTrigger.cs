using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public GameObject parentObject;
    public Collider boxCollider;
    public LayerMask targetLayers; // Layers of objects that trigger the event

    // todo: find way to change layers a game object can interact with. 
    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & targetLayers) != 0)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log(other.name + " entered the box trigger.");

                // Set collided object as child of the parent object 
                other.gameObject.transform.SetParent(parentObject.transform);

                // Change layer of game object to "Hands", where it can only interact with xr hands.
                other.gameObject.layer = LayerMask.NameToLayer("Hands");
                other.excludeLayers = LayerMask.NameToLayer("Default"); // NOT WORKING atm, resorted to ignoring collisions

                // Move the game object to the position of its parent. 
                other.transform.position = parentObject.transform.position;

                // Add the resourceInBox script as a component of the new child object
                other.gameObject.AddComponent<ResourceInBox>();

                // Get reference to newly attached script 
                ResourceInBox resourceScript = other.gameObject.GetComponent<ResourceInBox>();

                // Set triggerObject in new script to reference the current or "this" trigger
                resourceScript.triggerObject = gameObject; 

                // Make this trigger inactive 
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited by: " + other.name);
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
