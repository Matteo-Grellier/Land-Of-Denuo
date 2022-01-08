using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters
{
    public Animator animator;

    //for scene transition purpose 
    public static int lastTakenTpNumber;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTP();
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

    //To spawn the player at the good spot depending on wich teleporter he took
    void SpawnTP() {
        Vector3 position3 = new Vector3(8.78f, 0.06f, 0.0f);
        Vector3 position4 = new Vector3(-8.21f, 1.86f, 0.0f);

        switch(lastTakenTpNumber) {
            case 1:
                // code block
                break;
            case 2:
                // code block
                break;
            case 3:
                transform.position = position3;
                break;
            case 4:
                transform.position = position4;
                break;
            }
    }

}
