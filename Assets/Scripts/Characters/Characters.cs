using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Characters : MonoBehaviour
{
    
    //propriétés d'un personnage
    protected int maxHealth = 100;
    protected int health = 100;
    float defense = 0;
    float damage = 0;
    //mouvement d'un personnage
    protected Vector2 movement = new Vector2();
    public float speedMovement = 5f;
    public Rigidbody2D rb;

    public Vector3 positionToVerify;


    // Start is called before the first frame update
    void Start()
    {

        health = this.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int damage)
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

    public virtual void Die()
    {

        Destroy(gameObject);

    }
    
    void FixedUpdate()
    {
        if (Player.state == Player.State.isFishing)
        {

        }
        else {
            rb.MovePosition(rb.position + movement * speedMovement * Time.fixedDeltaTime);
        }

        
    }

    
}
