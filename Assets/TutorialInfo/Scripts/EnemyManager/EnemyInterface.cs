using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// dont even know if im going to use this
// a bit redundant?
public class EnemyInterface : MonoBehaviour
{
    private float speed;
    private int health;
    private int money;



    public EnemyInterface(float speed, int health, int money)
    {
        this.speed = speed;
        this.health = health;
        this.money = money;
    }

    public EnemyInterface(float speed, int health, int money, int multiplier)
    {
        this.speed = speed;
        this.health = health * multiplier;
        this.money = money;
    }

    public void takeDamage()
    {

    }

    void Die()
    {

    }
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
