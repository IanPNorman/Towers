using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ResourceInBox : MonoBehaviour
{ 
    public GameObject resourceInBox;
    public GameObject triggerObject; 

    // Start is called before the first frame update
    void Start()
    {
        resourceInBox = gameObject;
        Physics.IgnoreLayerCollision(8,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
