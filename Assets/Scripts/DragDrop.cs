using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas;

    private GameObject invObj;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("Inventory").GetComponent<Canvas>();
        invObj = GameObject.Find("Inventory");
    }
    public void OnBeginDrag(PointerEventData eventData)
    { 
        //throw new System.NotImplementedException();
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnEndsDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        rectTransform.anchoredPosition = new Vector2(0, 0); //si l'élément est laché dans le vide alors remise à zero.
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnPointerDown");

        //met l'index de l'actuel slot (celui que l'on veut interchanger) à celui du slot
        InventorySlot.actualIndexSlot = this.GetComponentInParent<InventorySlot>().indexOfSlot;

        //transform.parent.SetAsLastSibling();

        Debug.Log(InventorySlot.actualIndexSlot);
    }

}
