using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SupportBeamCheck : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    public BlueprintController blueprintController;
    public Material NewMaterial;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("WoodenBeam"))
        {
            rb = collision.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            grabInteractable = collision.GetComponent<XRGrabInteractable>();
            grabInteractable.enabled = false;
            GetComponent<Renderer>().material = NewMaterial;
            blueprintController.IncreaseCounter(1);
            Object.Destroy(collision.gameObject);
        }
    }
}