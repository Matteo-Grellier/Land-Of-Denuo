using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Characters
{
    protected Vector2 direction;
    public Animator animator;


    public Sprite fullHealth;
    public Sprite halHealth;
    public Sprite emptyHealth;

    public Image[] hearts;

    // Start is called before the first frame update
    void start()
    {
        health = this.maxHealth;
    }


    // Update is called once per frame
    void Update()
    {
        this.movement.x = Input.GetAxisRaw("Horizontal");
        this.movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(movement.x != 0 && movement.y == 0 || movement.x == 0 && movement.y != 0)
        {
            animator.SetFloat("PreviousHorizontal", movement.x);
            animator.SetFloat("PreviousVertical", movement.y);
        }

        Hearth();
    }

    public void Hearth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                if (i + 0.5 == health)
                {
                    hearts[i].sprite = halHealth;
                }
                else
                {
                    hearts[i].sprite = fullHealth;
                }
            }
            else
            {
                hearts[i].sprite = emptyHealth;
            }
        }
    }

    public void Heal()
    {
        if (health < 0)
        {
            health += 0.5f;

            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }

    }

    public void TakeDamage(float damage)
    {

        if (health > 0)
        {
            health -= damage;
        }


        if (health <= 0)
        {
            Hearth();
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
