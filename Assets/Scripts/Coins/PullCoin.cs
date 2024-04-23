using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PullCoin : MonoBehaviour
{
    [SerializeField] private Camera Player;
    public float speed = 6.5f;

    private void Update()
    {

        //Modify to work in VR and implement a range limit
        if (Input.GetKey("p"))
        {
            Vector3 direction = Player.transform.position - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }

}
