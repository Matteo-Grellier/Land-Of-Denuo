using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    public enum TypeOfItem
    {
        useless,
        weapon,
        fishingRod,
        armor
    }

    public int itemsAmount = 1;
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public TypeOfItem typeOfItem = TypeOfItem.useless;

    public void OnEnable()
    {
        itemsAmount = 1;
    }
}
