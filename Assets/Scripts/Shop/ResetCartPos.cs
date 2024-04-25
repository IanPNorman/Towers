using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResetCartPos : MonoBehaviour
{
    [SerializeField] private GameObject cart;
    public Vector3 spawnPoint;
    public void ResetPos(GameObject cart)
    {   
        
        cart.transform.SetPositionAndRotation(spawnPoint, Quaternion.identity);
        for (int i = 0; i < cart.transform.childCount; i++)
        {
            Transform child = cart.transform.GetChild(i);
            child.transform.SetPositionAndRotation(cart.transform.position, Quaternion.identity);
        }
        StopMotion(cart);
    }
    void StopMotion(GameObject obj)
    {
        // Stop the movement of the GameObject
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Stop the movement of the children
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            Transform child = obj.transform.GetChild(i);
            StopMotion(child.gameObject);
        }
    }
}
