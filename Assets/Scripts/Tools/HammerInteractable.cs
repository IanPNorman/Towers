using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HammerInteraction : MonoBehaviour
{
    // Optionally, reference other components or scripts that are affected by grabbing the hammer
    private void Start()
    {
    }

    void OnEnable()
    {
        var grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        grabInteractable.onSelectExited.AddListener(OnReleased);
        // You can also add listeners for activate and deactivate events if needed
    }

    void OnDisable()
    {
        var grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.RemoveListener(OnGrabbed);
        grabInteractable.onSelectExited.RemoveListener(OnReleased);
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        Debug.Log("Hammer grabbed");
        // Activate functionality
    }

    private void OnReleased(XRBaseInteractor interactor)
    {
        Debug.Log("Hammer released");
        // Deactivate functionality or reset states
    }
}
