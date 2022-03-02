using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{

    public Image icon;

    Item item;

    public int indexOfSlot;

    public bool isDeleteSlot = false;

    static public int actualIndexSlot;
    static int requestSwapSlot;

    public void AddItem(Item newItem, int indexOfItem)
    {
        item = newItem;

        this.indexOfSlot = indexOfItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        this.indexOfSlot = -1;

        icon.sprite = null;

        if(!isDeleteSlot)
        {
            icon.enabled = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {

        if(isDeleteSlot)
        {
            transform.parent.GetComponentInParent<InventoryUI>().DeleteItemsUI(actualIndexSlot);
        }

        //throw new System.NotImplementedException();
        Debug.Log("OnDrop");

        //on définit la variable de la case où l'on veut mettre l'élément.
        requestSwapSlot = indexOfSlot;

        Debug.Log(indexOfSlot);
        
        //On appelle la fonction SwapItemsUI() (celle de l'élément "inventory" donc il faut chercher les parents)
        transform.parent.GetComponentInParent<InventoryUI>().SwapItemsUI(actualIndexSlot, requestSwapSlot);

    }

}
