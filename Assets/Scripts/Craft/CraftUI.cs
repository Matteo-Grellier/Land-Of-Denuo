using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftUI : MonoBehaviour
{

    public static CraftingStation actualCraftingStation;

    public GameObject CraftSlots;

    public void VerifyPossibilityToCraft(int indexOfChild)
    {
        Craft actualCraft = actualCraftingStation.crafts[indexOfChild];

        bool isValid = CompareToCraft(actualCraft);

        if (isValid)
        {
            //Si le joueur � tous les �l�ments n�cessaires
            ChangeValue(actualCraft);
        }

    }

    private bool CompareToCraft(Craft actualCraft)
    {
        bool isValid = false;

        //Comparer les ingr�dients d'un craft avec les items dans l'inventaire.
        for (int i = 0; i < actualCraft.ingredients.Length; i++)
        {
            foreach (Item inventoryItem in Inventory.instance.items)
            {

                if(inventoryItem.name == actualCraft.ingredients[i].name && inventoryItem.itemsAmount >= actualCraft.numberOfItems[i])
                {
                    isValid = true;
                    break;
                } else
                {
                    isValid = false;
                }

            }

            if (!isValid)
            {
                break;
            }
        }

        return isValid;
    }

    private void ChangeValue(Craft actualCraft)
    {

        for (int i = 0; i < actualCraft.ingredients.Length; i++)
        {
            foreach (Item inventoryItem in Inventory.instance.items)
            {

                if (inventoryItem.name == actualCraft.ingredients[i].name)
                {
                    inventoryItem.itemsAmount -= actualCraft.numberOfItems[i]; //Enlever le nombre d'�l�ment n�cessaire pour le craft

                    //Si le nombre d'objet est inf�rieur ou �gal � 0, alors on le supprime de l'inventaire.
                    if(inventoryItem.itemsAmount <= 0)
                    {
                        Inventory.instance.Remove(inventoryItem);
                    }

                    break;
                }
            }
        }

        Inventory.instance.Add(actualCraft.result);
    }
}
