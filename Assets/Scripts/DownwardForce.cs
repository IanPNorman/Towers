using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownwardForce : MonoBehaviour
{

    public float downwardForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.down * downwardForce, ForceMode.Force);
    }
}
