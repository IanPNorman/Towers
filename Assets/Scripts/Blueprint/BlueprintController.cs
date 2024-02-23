using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintController : MonoBehaviour
{
    [SerializeField] private GameObject Blueprint;
    [SerializeField] private GameObject FinishedTower;
    void Update()
    {
        if(Blueprint.transform.childCount <= 0)
        {
            Instantiate(FinishedTower, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            Object.Destroy(Blueprint);
        }
    }
}
