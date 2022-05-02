using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Craft", menuName = "Craft")]
public class Craft : ScriptableObject
{
    new public string name = "New Craft";

    public Item[] ingredients = new Item[4];
    public int[] numberOfItems = new int[4];

    public Item result;

}
