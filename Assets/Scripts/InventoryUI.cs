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
                slots[i].AddItem(inventory.items[i], i);
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void SwapItemsUI(int actualSlot, int requestSlot)
    {
        //échange de la place dans le tableau, des items.
        (inventory.items[actualSlot], inventory.items[requestSlot]) = (inventory.items[requestSlot], inventory.items[actualSlot]);

        //remise à zero de la position de l'item de base.
        slots[actualSlot].icon.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);

        //mise à jour de l'UI.
        UpdateUI();
    }
}
