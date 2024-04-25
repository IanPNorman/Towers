using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPartButton : MonoBehaviour
{
    [SerializeField] private GameObject part;
    public Transform head;
    public void SpawnPart(GameObject part)
    {
        if (part == null)
        {
            Debug.LogError("No part selected to be spawned.");
        }
        else
        {
            Instantiate(part, head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * 2, Quaternion.Euler(90f,0f,90f));
        }
    }
}
