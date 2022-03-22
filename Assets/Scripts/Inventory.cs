using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found !");
            return;
        }
        instance = this;

    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();

    public int space = 200;

    public Tool toolUsed;

    public bool Add(Item item)
    {
        bool isAlreadyExist = false;

        Item copyItem = Instantiate(item);
        int indexOfExistingElement = items.FindIndex(item => copyItem.name == item.name);

        if(indexOfExistingElement > -1)
        {
            items[indexOfExistingElement].itemsAmount++;
            isAlreadyExist = true;
        }

        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough space.");
                return false;
            }

            if(!isAlreadyExist)
            {
                items.Add(item);
            }
            
            if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    //public void ToolUsed(Item item)
    //{
    //    toolUsed = item;
    //}
}
