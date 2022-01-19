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

    public Animator animator;
    public float targetRange = 5f;
    private bool findTarget;
    private Vector2 moveDirection;
    private State state;

    private void Awake()
    {
        Debug.Log(rb.gameObject);
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
                moveEnemy(rb.transform.position); //RigidBody du player
                break;
            default:    
                break;
        }

    }

    private void FindTarget()
    {
        if (Vector2.Distance(transform.position, rb.transform.position) < targetRange)
        {
            state = State.chaseTarget;
        }
    }

    public void moveEnemy(Vector2 p)
    {
        //Debug.Log(Player.Instance.transform.position.x - transform.position.x);
        //movement = new Vector2(Player.transform.position.x, Player.transform.position.y);
        //rb.MovePosition(rb.position + (movement * speedMovement * Time.fixedDeltaTime));
        //Debug.Log(Player.Instance.transform.position.x - transform.position.x);
        //Debug.Log(Player.Instance.transform.position.y - transform.position.y);

        if (p.x - transform.position.x == 0)
        {
            animator.SetFloat("Horizontal", p.x);

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, p.y), speedMovement * Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Vertical", p.y);

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(p.x, transform.position.y), speedMovement * Time.deltaTime);
        }

        //if (p.x > transform.position.x)
        //{
        //    movement.x = 1;
        //} else if (p.x < transform.position.x)
        //{
        //    movement.x = -1;
        //} else if (p.y > transform.position.y)
        //{
        //    movement.y = 1;
        //}
        //else if (p.y < transform.position.y)
        //{
        //    movement.y = -1;
        //}


        //if (Player.Instance.transform.position.x - GameObject.Find("Enemy").transform.position.x > 0 && Player.Instance.transform.position.y - GameObject.Find("Enemy").transform.position.y > 0)
        //{
        //    movement = new Vector2(0.5f, 0.5f);
        //    rb.MovePosition(rb.position + (speedMovement * Time.fixedDeltaTime * movement));
        //}
    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.name == "Player")
    //    {
    //        checkTrigger = false;
    //    }
    //}
}
