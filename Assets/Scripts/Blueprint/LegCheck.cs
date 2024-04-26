using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegCheck : MonoBehaviour
{
    public BlueprintController blueprintController;
    public Material NewMaterial;


    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("WoodenLeg"))
        {
            GetComponent<Renderer>().material = NewMaterial;
            Object.Destroy(collision.gameObject);
            blueprintController.IncreaseCounter(1);
        }
    }
}
