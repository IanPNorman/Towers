using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportBeamCheck : MonoBehaviour
{

    [SerializeField] private Rigidbody SupportBeam;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BlueprintSupportBeam")
        {

            SupportBeam.constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = collision.transform.position;
            this.transform.rotation = collision.transform.rotation;

            Object.Destroy(collision.gameObject);
        }
    }
}