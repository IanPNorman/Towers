using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintController : MonoBehaviour
{
    [SerializeField] private GameObject Blueprint;
    [SerializeField] private GameObject FinishedTower;
    [SerializeField] private List<int> Counter = new List<int>();
    void Update()
    {

        if(Counter.Count >= 9)
        {
            Instantiate(FinishedTower, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            Object.Destroy(Blueprint);
        }
    }

    public void IncreaseCounter(int increase)
    {
        Counter.Add(increase);
    }

}
