using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LegCheck : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    public BlueprintController blueprintController;
    public Material NewMaterial;


    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("WoodenLeg"))
        {
            rb = collision.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            grabInteractable = collision.GetComponent<XRGrabInteractable>();
            grabInteractable.enabled = false;
            GetComponent<Renderer>().material = NewMaterial;
            GetComponent<Collider>().isTrigger = false;
            Object.Destroy(collision.gameObject);
            blueprintController.IncreaseCounter(1);
            AudioManager.Instance.PlaySFX("Building_Place");
        }
    }
}
