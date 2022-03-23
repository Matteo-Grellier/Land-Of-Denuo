using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && isInTriggeredZone)
        {
            Pickup();
        }
    }

    //public override void Interact()
    //{
    //    base.Interact();

    //    Pickup();
    //}

    void Pickup()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        Debug.Log("value of bool wasPickedUp : " + wasPickedUp);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
