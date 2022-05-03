using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crafting Station", menuName = "CraftingStation")]
public class CraftingStation : ScriptableObject
{
    new public string name = "Crafting Menu";

    public Craft[] crafts = new Craft[5];
}
