using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaformBlueprint : MonoBehaviour
{

    public BlueprintController blueprintController;
    public Material NewMaterial;


    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("WoodenPlatform"))
        {
            GetComponent<Renderer>().material = NewMaterial;
            Object.Destroy(collision.gameObject);
            blueprintController.IncreaseCounter(1);
        }
    }
}
