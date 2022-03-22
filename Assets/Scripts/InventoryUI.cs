using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public Transform utilsSlot;

    public static bool inventoryIsOpen = false;
    public GameObject inventoryUI;

    public int offsetIndexToDisplay = 0;

    Inventory inventory;

    //Les �l�ments visuel de l'inventaire (les diff�rentes cases de l'inventaire)
    static InventorySlot[] slots; //static ajout� au fealing.
    static InventorySlot toolSlot;
    static InventorySlot armorSlot;


    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        Debug.Log(itemsParent.childCount);


        //R�cup�rer les �l�ments enfants qui ont la propri�t� "InventorySlot" (donc qui sont des emplacements visuels)
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); //Dans itemsParent on r�cup�re tous les slots
        toolSlot = utilsSlot.GetComponentsInChildren<InventorySlot>()[1]; //Dans utilsSlot on r�cup�re l'emplacement pour les outils
        armorSlot = utilsSlot.GetComponentsInChildren<InventorySlot>()[0]; //Dans utilsSlot on r�cup�re l'emplacement pour l'armure.

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

        if(inventory.toolUsed != null)
        {
            toolSlot.AddItem(inventory.toolUsed, -1);
        }
    }

    //peut-�tre d�placer la fonction dans Inventory.cs (car pas forc�ment li� � l'UI)
    public void SwapItemsUI(int actualSlot, int requestSlot)
    {
        //Si la case choisi est vide alors remise � la position initiale de l'�l�ment
        if(requestSlot == -1)
        {
            slots[actualSlot].icon.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            UpdateUI();// Permet de mettre � jour dans le cas des outils et armures.
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
