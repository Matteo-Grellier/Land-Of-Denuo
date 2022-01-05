using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    static InventorySlot[] slots; //static ajouté au fealing.

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        Debug.Log(itemsParent.childCount);

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        Debug.Log("I start in Start");
        Debug.Log(slots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        Debug.Log("It's : " + slots.Length);

        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
