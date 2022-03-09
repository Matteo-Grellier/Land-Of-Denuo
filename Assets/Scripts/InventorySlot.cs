using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{

    public Image icon;

    public TextMeshProUGUI numberOfEl;

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

        //r�cup�rer TextMeshPro de l'autre enfant du parent.
        //Debug.Log(transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>());
        //transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.itemsAmount.ToString();
        if(!isDeleteSlot)
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

        if(!isDeleteSlot)
        {
            icon.enabled = false;
            numberOfEl.text = "";
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

        //on d�finit la variable de la case o� l'on veut mettre l'�l�ment.
        requestSwapSlot = indexOfSlot;

        Debug.Log(indexOfSlot);
        
        //On appelle la fonction SwapItemsUI() (celle de l'�l�ment "inventory" donc il faut chercher les parents)
        transform.parent.GetComponentInParent<InventoryUI>().SwapItemsUI(actualIndexSlot, requestSwapSlot);

    }

}
