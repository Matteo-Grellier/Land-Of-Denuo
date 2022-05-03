using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CraftSystem : Interactable
{

    public CraftingStation craftingStation;
    //private static CraftingStation actualCraftingStation;

    public GameObject CraftMenu;
    public GameObject CraftSlots;

    public TextMeshProUGUI nameOfCraftingStation;

    public bool isOpenCraftMenu;

    // Start is called before the first frame update
    void Start()
    {
        nameOfCraftingStation = CraftMenu.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isInTriggeredZone)
        {

            if (!isOpenCraftMenu) {
                OpenCraftMenu();
            } else
            {
                CloseCraftMenu();
            }
        }

    }

    private void OpenCraftMenu()
    {
        CraftMenu.SetActive(true);
        nameOfCraftingStation.text = craftingStation.name; //Change le texte du menu de craft (défini dans le Start())
        CraftUI.actualCraftingStation = craftingStation;
        DisplayCrafts();
        isOpenCraftMenu = true;
    }

    private void CloseCraftMenu()
    {
        CraftMenu.SetActive(false);
        isOpenCraftMenu = false;
    }

    private void DisplayCrafts()
    {
        //GameObject[] crafts = CraftSlots.transform.GetChild();

        for (int i = 0; i < craftingStation.crafts.Length; i++)
        {
            InventorySlot[] slots = CraftSlots.transform.GetChild(i).GetComponentsInChildren<InventorySlot>();

            Craft actualCraft = craftingStation.crafts[i];

            for (int j = 0; j < actualCraft.ingredients.Length; j++) //parcours les éléments dans le craft
            {
                slots[j].icon.sprite = actualCraft.ingredients[j].icon;
                slots[j].numberOfEl.text = actualCraft.numberOfItems[j].ToString();
                slots[j].icon.enabled = true;
            }

            slots[4].icon.sprite = actualCraft.result.icon;
            slots[4].icon.enabled = true;
        }
    }
}

