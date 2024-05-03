using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HammerPlace : MonoBehaviour
{
    public XRRayInteractor rayInteractor;

    [SerializeField] private GameObject placeableObjectPrefabs;

    private GameObject currentPlaceableObject;

    public void Update()
    {

        if (currentPlaceableObject != null)
        {
            Destroy(currentPlaceableObject);
        }  
        else
        {
            currentPlaceableObject = Instantiate(placeableObjectPrefabs);
        }
        if (currentPlaceableObject != null)
        {
            MoveBlueprintAround();
        }

    }

    public void MoveBlueprintAround()
    {
        RaycastHit res;
        if (rayInteractor.TryGetCurrent3DRaycastHit(out res))
        {
            Vector3 groundPt = res.point;
            currentPlaceableObject.transform.position = groundPt;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, groundPt.normalized);
        }
    }
}