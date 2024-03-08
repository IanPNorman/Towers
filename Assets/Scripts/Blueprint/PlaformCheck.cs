using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaformBlueprint : MonoBehaviour
{

    [SerializeField] private Rigidbody Platform;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BlueprintPlatform")
        {

            Platform.constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = collision.transform.position;
            this.transform.rotation = collision.transform.rotation;

            Object.Destroy(collision.gameObject);
        }
    }
}
