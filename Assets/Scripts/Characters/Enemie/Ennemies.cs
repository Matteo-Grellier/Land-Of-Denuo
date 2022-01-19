using Assets.Scripts.Characters.Enemie;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemies : Characters
{
    private enum State
    {
        Waiting,
        chaseTarget,

    }

    private EnemyMovements EnemyMovements;
    public Animator animator;
    private bool findTarget;
    private Vector3 moveDirection;
    private State state;

    private void Awake()
    {
        EnemyMovements = rb.GetComponent<EnemyMovements>();
        Debug.Log(EnemyMovements);
        state = State.Waiting;
    }


    // Start is called before the first frame update
    void Start()
    {
        health = this.maxHealth;
    }

    // Update is called once per frame

    void Update()
    {
        switch (state)
        {
            case State.Waiting:
                FindTarget();
                break;
            case State.chaseTarget:
                EnemyMovements.moveEnemy(rb.transform.position);
                break;
            default:    
                break;
        }

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

    void Die()
    {
        Destroy(gameObject);
    }

  

    private void FindTarget()
    {
        float targetRange = 5f;
        if (Vector3.Distance(transform.position, rb.transform.position) < targetRange)
        {
            state = State.chaseTarget;
        }
    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.name == "Player")
    //    {
    //        checkTrigger = false;
    //    }
    //}
}
