using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters
{
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
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
    }

}
