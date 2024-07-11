using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class ItemSlot : MonoBehaviour, IDropHandler , IPointerEnterHandler, IPointerExitHandler 
{
    private bool isHovering = false;
    private PointerEventData EventData;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject DraggableItem = eventData.pointerDrag;
            InventoryItem inventoryItem = DraggableItem.GetComponent<InventoryItem>();
            inventoryItem.ParentBeforeMoving = transform;
        }
        else
        {
            Debug.Log("space Occupied");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        isHovering = true;
        EventData = eventData;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        EventData = null;
    }

    private void Update()
    {
        if(isHovering == true)
        {
            GameObject slot = EventData.pointerCurrentRaycast.gameObject;
            InventoryItem inventoryItem = slot.GetComponentInChildren<InventoryItem>();
            if (inventoryItem != null)
            {
                if(Input.GetMouseButtonDown(1))
                {
                    inventoryItem.UseItem();

                }
               





            }
        }
    }

}
   

       


   
