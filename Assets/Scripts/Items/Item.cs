using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int itemsAmount = 1;
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public void OnEnable()
    {
        itemsAmount = 1;
    }
}
