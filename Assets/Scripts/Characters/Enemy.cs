using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Characters
{
    //public Transform Player;
    public Animator animator;
    private bool checkTrigger;
    public GameObject target;
    private float timeToMoveCounter;
    public GameObject Ennemies;
    private bool moving;
    public float timeBetweenMove;
    private Vector3 moveDirection;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        moveEnemy();
    }


    void moveEnemy()
    {
        Debug.Log(target.transform.position.x - Ennemies.transform.position.x);
        //movement = new Vector2(Player.transform.position.x, Player.transform.position.y);
        //rb.MovePosition(rb.position + (movement * speedMovement * Time.fixedDeltaTime));
        Debug.Log(target.transform.position.x - Ennemies.transform.position.x);
        Debug.Log(target.transform.position.y - Ennemies.transform.position.y);

        //if (target.transform.position.x - Ennemies.transform.position.x == 0)
        //{
        //    animator.SetFloat("Horizontal", target.transform.position.x);

        //    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, target.transform.position.y), speedMovement * Time.deltaTime);
        //}
        //else
        //{
        //    animator.SetFloat("Vertical", target.transform.position.y);

        //    transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x, transform.position.y), speedMovement * Time.deltaTime);
        //}
        //if (target.transform.position.x - GameObject.Find("Enemy").transform.position.x > 0 && target.transform.position.y - GameObject.Find("Enemy").transform.position.y > 0)
        //{
        //    movement = new Vector2(0.5f, 0.5f);
        //    rb.MovePosition(rb.position + (speedMovement * Time.fixedDeltaTime * movement));
        //}
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.name == "Player")
    //    {
    //        checkTrigger = true;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.name == "Player")
    //    {
    //        checkTrigger = false;
    //    }
    //}
}