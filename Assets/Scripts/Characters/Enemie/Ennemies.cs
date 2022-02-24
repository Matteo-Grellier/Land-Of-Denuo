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
                break;
            case State.chaseTarget:
                moveEnemy(target.transform.position); //RigidBody du player
                break;
            default:    
                break;
        }

    }

    private void FindTarget()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < targetRange)
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
        
        animator.SetFloat("Speed", (rb.position * speedMovement).magnitude);

        Debug.Log("###" + (rb.position * speedMovement).magnitude ); 

        Vector2 distance = new Vector2(targetPosition.x - transform.position.x , targetPosition.y - transform.position.y);
        // Debug.Log("######" + distance.x + " " + distance.y);

        animator.SetFloat("Horizontal", distance.x);
        animator.SetFloat("Vertical", distance.y);

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
