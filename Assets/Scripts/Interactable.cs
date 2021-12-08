using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //public Collider triggeredZone;
    //public GameObject player;

    protected bool isInTriggeredZone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void FixedUpdate()
    //{
    //    //triggeredZone.OnTriggerEnter(player);
    //}

    //bool isTriggered()
    //{
    //    //if(player.IsTouching)

    //    return false;
    //}

    //public virtual void Interact()
    //{
    //    Debug.Log("Interacting with " + transform.name);
    //}

    //public void OnTriggerEnter(Collider col)
    //{
    //    if(col.name == "Player")
    //    {
    //        Debug.Log("hello cest mpi le player qui rentre");
    //    }
    //    //isTouching = true;
    //    Debug.Log("coucou");
    //}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            Debug.Log("hello cest moi le player qui rentre");
            isInTriggeredZone = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            Debug.Log("hello cest moi le player qui sort");
            isInTriggeredZone = false;
        }
    }
}
