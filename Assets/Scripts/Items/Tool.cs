using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Inventory/Tool")]
public class Tool : Item
{
    public int damage = 0;
    public string description = "Nothing";
}
