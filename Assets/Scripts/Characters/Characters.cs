using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Characters : MonoBehaviour
{

    //propri�t�s d'un personnage
    public float maxHealth;
    public float health;
    float defense = 0;
    float damage = 0;




    //mouvement d'un personnage
    protected Vector2 movement = new Vector2();
    public float speedMovement = 5f;

    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void TakeDamage(float damage)
    {

        if (health > 0)
        {
            health -= damage;
        }


        if (health <= 0)
        {
            Die();

        }

    }

    void Die()
    {

        Destroy(gameObject);

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speedMovement * Time.fixedDeltaTime);
    }
}
