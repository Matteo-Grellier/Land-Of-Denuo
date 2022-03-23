using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemies : Characters
{
    public enum State
    {
        Waiting,
        chaseTarget,
        Attack,
    }

    public Animator animator;
    public float targetRange = 5f;
    private bool findTarget;
    private Vector2 moveDirection;
    public State state;
    public Rigidbody2D target;

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
                Debug.Log("STATE : WAITING");
                break;
            case State.chaseTarget:
                moveEnemy(target.transform.position); //RigidBody du player
                Debug.Log("STATE : MOVING TO TARGET");
                break;
            case State.Attack:
                Attack();
                Debug.Log("STATE : ATTACK");
                break;
            default:    
                break;
        }

    }

    private void FindTarget()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < targetRange && Vector2.Distance(transform.position, target.transform.position) > 1.5f )
        {
            state = State.chaseTarget;
        }
    }

    private void Attack()
    {
        if ( Vector2.Distance(transform.position, target.transform.position) > targetRange )
        {
            state = State.chaseTarget;
        }
    }

    public void moveEnemy(Vector2 targetPosition)
    {
        //Debug.Log(Player.Instance.transform.position.x - transform.position.x);
        //movement = new Vector2(Player.transform.position.x, Player.transform.position.y);
        // rb.MovePosition(rb.position + (movement * speedMovement * Time.fixedDeltaTime));
        //Debug.Log(Player.Instance.transform.position.x - transform.position.x);
        //Debug.Log(Player.Instance.transform.position.y - transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speedMovement * Time.deltaTime);

        Vector2 distance = new Vector2(targetPosition.x - transform.position.x , targetPosition.y - transform.position.y);
        // Debug.Log("######" + distance.x + " " + distance.y);
        float flatDistance = (Mathf.Abs(distance.x) + Mathf.Abs(distance.y));

        animator.SetFloat("Distance", flatDistance); // animator.SetFloat("Speed", (rb.position * speedMovement).magnitude);
        // Debug.Log("Distance = " + flatDistance );

        animator.SetFloat("Horizontal", distance.x);
        animator.SetFloat("Vertical", distance.y);

        if ( flatDistance > targetRange * 2 )
        {
            state = State.Waiting;
            animator.SetFloat("Distance", 0f);
        }
        else if (flatDistance <= 1.5f) 
        {
            state = State.Attack;
        }

        //if (p.x - transform.position.x == 0)
        //{
        //    animator.SetFloat("Horizontal", p.x);

        //    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, p.y), speedMovement * Time.deltaTime);
        //}
        //else
        //{
        //    animator.SetFloat("Vertical", p.y);

        //    transform.position = Vector2.MoveTowards(transform.position, new Vector2(p.x, transform.position.y), speedMovement * Time.deltaTime);
        //}
    }

}
