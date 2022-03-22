using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public enum TypeOfSlot
    {
        inventorySlot,
        deleteSlot,
        toolSlot,
        armorSlot
    }

    public Image icon;

    public TextMeshProUGUI numberOfEl;

    Item item;

    public int indexOfSlot;

    //public bool isDeleteSlot = false;
    public TypeOfSlot typeOfSlot = TypeOfSlot.inventorySlot;

    static public int actualIndexSlot;
    static int requestSwapSlot;

    public void AddItem(Item newItem, int indexOfItem)
    {
        item = newItem;

        this.indexOfSlot = indexOfItem;

        icon.sprite = item.icon;
        icon.enabled = true;

        //récupérer TextMeshPro de l'autre enfant du parent.
        //Debug.Log(transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>());
        //transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.itemsAmount.ToString();
        if(typeOfSlot == TypeOfSlot.inventorySlot)
        {
            numberOfEl.text = item.itemsAmount.ToString();
        }
        
    }

    public void ClearSlot()
    {
        item = null;
        this.indexOfSlot = -1;

        Debug.Log(numberOfEl);

        icon.sprite = null;

        if(typeOfSlot == TypeOfSlot.inventorySlot)
        {
            icon.enabled = false;
            numberOfEl.text = "";
        }
    }

    public void OnDrop(PointerEventData eventData)
    {

        if(typeOfSlot == TypeOfSlot.deleteSlot)
        {
            transform.parent.GetComponentInParent<InventoryUI>().DeleteItemsUI(actualIndexSlot);

        } else if (typeOfSlot == TypeOfSlot.toolSlot && Inventory.instance.items[actualIndexSlot].GetType() == typeof(Tool)) // Sinon si le type du slot visé est "toolSlot" et que le type de l'item est un "Tool"
        {
            Inventory.instance.toolUsed = (Tool) Inventory.instance.items[actualIndexSlot];
            //Pour mettre à jour l'UI, ça se fait au niveau de SwapItemsUI (plus bas)
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
