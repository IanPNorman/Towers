using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Placer : MonoBehaviour
{
    //Placer code maybe adaapted for VR
    public XRRayInteractor rayInteractor;

    [SerializeField] private GameObject placeableObjectPrefabs;

    private GameObject currentPlaceableObject;



    private void Update()
    {

        if (rayInteractor != null)
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            else
            {
                currentPlaceableObject = Instantiate(placeableObjectPrefabs);
            }
        }
        if (currentPlaceableObject != null)
        {
            MoveCurrentObjectToMouse();
            ReleaseIfClicked();
        }

    }

    private void MoveCurrentObjectToMouse()
    {
        RaycastHit res;
        if (rayInteractor.TryGetCurrent3DRaycastHit(out res))
        {
            Vector3 groundPt = res.point;
            currentPlaceableObject.transform.position = groundPt;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, groundPt.normalized);
        }
    }


    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject = null;
        }
    }
}