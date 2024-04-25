using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableScale : XRGrabInteractable
{
    private GameObject grabbedObj;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactableObject.transform.CompareTag("Large Part"))
        {
            grabbedObj = args.interactableObject.transform.gameObject;

            grabbedObj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }

        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        grabbedObj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        grabbedObj = null;
        base.OnSelectExited(args);
    }
}
