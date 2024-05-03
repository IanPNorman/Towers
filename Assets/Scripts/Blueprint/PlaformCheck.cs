using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaformBlueprint : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    public BlueprintController blueprintController;
    public Material NewMaterial;


    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("WoodenPlatform"))
        {
            rb = collision.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            grabInteractable = collision.GetComponent<XRGrabInteractable>();
            grabInteractable.enabled = false;
            GetComponent<Renderer>().material = NewMaterial;
            Object.Destroy(collision.gameObject);
            blueprintController.IncreaseCounter(1);
        }
    }
}
