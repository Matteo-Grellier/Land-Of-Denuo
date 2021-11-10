using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{

    //propriétés d'un personnage
    float maxHealth = 100;
    float health = 100;
    float defense = 0;
    float damage = 0;

    //mouvement d'un personnage
    protected Vector2 movement = new Vector2();
    float speedMovement = 5f;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speedMovement * Time.fixedDeltaTime);
    }
}
