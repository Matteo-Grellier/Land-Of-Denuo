using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pnj : MonoBehaviour
{
    public Animator animator;
    public bool back;
    public bool left;
    public bool right;

    private bool playerInCollider = false;
    private bool inDialog = false;

    public string text = "nothing";

    public GameObject activeBulle;
    public GameObject txt;

    void Start()
    {
        txt.GetComponent<TextMeshPro>().text = text;
        if (back == true )
        {
            animator.SetBool("Back", true);
        }
        if (left == true )
        {
            animator.SetBool("Left", true);
        }
        if (right == true )
        {
            animator.SetBool("Right", true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInCollider = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInCollider = false;
            EndDialog();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInCollider == true)
        {
            if (inDialog == false)
            {
                Dialog();
            }
            else 
            {
                EndDialog();
            }
        }
    }

    void Dialog()
    {
        inDialog = true;
        activeBulle.GetComponent<Renderer>().enabled = true;
        txt.GetComponent<Renderer>().enabled = true;
    }

    void EndDialog()
    {
        inDialog = false;
        activeBulle.GetComponent<Renderer>().enabled = false;
        txt.GetComponent<Renderer>().enabled = false;
    }
}
