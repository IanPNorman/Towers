using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class SupportBeamCheck : MonoBehaviour
{
    public BlueprintController blueprintController;
    public Material NewMaterial;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("WoodenBeam"))
        {
            GetComponent<Renderer>().material = NewMaterial;
            blueprintController.IncreaseCounter(1);
            Object.Destroy(collision.gameObject);
        }
    }
}