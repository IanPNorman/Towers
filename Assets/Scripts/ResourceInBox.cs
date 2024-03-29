using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ResourceInBox : MonoBehaviour
{ 
    public GameObject resourceInBox;
    public GameObject triggerObject;
    public int objectNumber;

    void Start()
    {
        resourceInBox = gameObject;
        // Physics.IgnoreLayerCollision(8,0);
    }

    void Update()
    {
        {
            // Position of the resource is locked in relation to the transform of the parent
            Transform parentTransform = resourceInBox.transform.parent;

            if (parentTransform != null)
            {
                // Get the parent's position components
                float parentPosX = parentTransform.position.x;
                float parentPosY = parentTransform.position.y;
                float parentPosZ = parentTransform.position.z;

                // Assign the individual x, y, z coordinates to the resource's position
                Vector3 newPosition = new Vector3(parentPosX, parentPosY, parentPosZ);
                resourceInBox.transform.position = newPosition;
            }
        }
    }


}
