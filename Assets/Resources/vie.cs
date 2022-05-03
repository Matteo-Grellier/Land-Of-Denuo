using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vie : MonoBehaviour
{
    public float maxHealth;
    /*protected float currentHealth;*/
    public float health;

    public Sprite fullHealth;
    public Sprite halHealth;
    public Sprite emptyHealth;

    public Image[] hearts;

    void start()
    {
        health = maxHealth;
    }

    void Update()
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

    /*public void takeDamage()
    {
        if (health > 0)
        {
            health -= 0.5f;

            if (health < 0)
            {
                health = 0;
            }
        }
    }


    public void Heal()
    {
        if (currentHealth < 0)
        {
            currentHealth += 0.5f;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }*/
}
