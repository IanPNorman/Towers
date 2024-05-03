using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HammerShow : MonoBehaviour
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
            ReleaseIfClicked();
        }

    }

    private void ReleaseIfClicked()
    {
        currentPlaceableObject = null;
    }
}