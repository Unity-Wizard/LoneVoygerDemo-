using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class BackGround : MonoBehaviour , IDropHandler
{

    public Transform DropItem;

     public void OnDrop(PointerEventData eventData)
    {
        
            GameObject DraggableItem = eventData.pointerDrag;
            InventoryItem inventoryItem = DraggableItem.GetComponent<InventoryItem>();

            if(inventoryItem != null){
                 Debug.Log("Throwed");
                 Vector3 Rotation = new Vector3(90 , 0 , 60);
                Instantiate(inventoryItem.item.Prefab , DropItem.position ,Quaternion.Euler(Rotation));
               
                 inventoryItem.Count--;
               inventoryItem.RefreshCount();
                 
            }
           
            
    }

    
       
}
