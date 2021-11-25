using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currenthealth;

    // Update is called once per frame
    void start()
    {
        currenthealth = maxHealth;

    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;


        if(currenthealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died !");
    }
}
