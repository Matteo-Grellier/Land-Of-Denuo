using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    public static bool inventoryIsOpen = false;
    public GameObject inventoryUI;

    public int offsetIndexToDisplay = 0;

    Inventory inventory;

    static InventorySlot[] slots; //static ajout� au fealing.


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
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryIsOpen)
            {
                CloseInventory();
            } else
            {
                OpenInventory();
            }
        }
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        Debug.Log("It's : " + slots.Length);

        for(int i = 0; i < slots.Length; i++)
        {

            if(i+ offsetIndexToDisplay < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i+offsetIndexToDisplay], i);
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }

    //peut-�tre d�placer la fonction dans Inventory.cs (car pas forc�ment li� � l'UI)
    public void SwapItemsUI(int actualSlot, int requestSlot)
    {
        //Si la case choisi est vide alors remise � la position initiale de l'�l�ment
        if(requestSlot == -1)
        {
            slots[actualSlot].icon.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            return;
        }

        //�change de la place dans le tableau, des items.
        (inventory.items[actualSlot], inventory.items[requestSlot]) = (inventory.items[requestSlot], inventory.items[actualSlot]);

        //remise � zero de la position de l'item de base.
        slots[actualSlot].icon.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);

        //mise � jour de l'UI.
        UpdateUI();
    }

    public void DeleteItemsUI(int actualSlot)
    {

        inventory.Remove(inventory.items[actualSlot]);
        
        //mise � jour de l'UI.
        UpdateUI();
    }

    private void OpenInventory()
    {
        inventoryUI.SetActive(true);
        inventoryIsOpen = true;
    }

    private void CloseInventory()
    {
        inventoryUI.SetActive(false);
        inventoryIsOpen = false;
    }

    public void ToPreviousInventoryPage()
    {
        if(offsetIndexToDisplay > 0)
        {
            offsetIndexToDisplay -= 20;
        }else
        {
            return;
        }

        UpdateUI();
    }

    public void ToNextInventoryPage()
    {
        if(offsetIndexToDisplay < slots.Length)
        {
            offsetIndexToDisplay += 20;
        } else
        {
            return;
        }

        UpdateUI();
    }
}
