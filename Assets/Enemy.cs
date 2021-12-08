using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currenthealth;
   

    // Update is called once per frame
    void Start()
    {
        currenthealth = maxHealth;

    }

    public void TakeDamage(int damage)
    {

        if (currenthealth > 0)
        {
            currenthealth -= damage;
        }


        if(currenthealth <= 0)
        {
            Die();
         
        }
    }

    void Die()
    {

        Destroy(gameObject);
        
    }
}
