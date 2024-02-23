using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegCheck : MonoBehaviour
{

    [SerializeField] private Rigidbody WoodenLeg;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BlueprintLeg")
        {
            
            WoodenLeg.constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = collision.transform.position;
            this.transform.rotation = collision.transform.rotation;

            Object.Destroy(collision.gameObject);
        }
    }
}
