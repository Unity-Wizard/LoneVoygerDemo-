using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler ,IPointerDownHandler,IPointerUpHandler , IDropHandler
{
    public static InventoryItem Instance { get; private set; }


    public Image image;
    public Transform ParentBeforeMoving;
    public Text ItemCountText;

   [HideInInspector] public Item item;
   [HideInInspector] public int Count = 1;


    private void Awake()
    {
        Instance = this;
    }

    

    public void InatializeItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    
    }

    public void RefreshCount()
    {
        ItemCountText.text = Count.ToString();
       if (ItemCountText.text == "1")
        {
            ItemCountText.gameObject.SetActive(false);
        }
        else
        {
            ItemCountText.gameObject.SetActive(true);

        }

        if(Count == 0)
        {
           Destroy(this.gameObject);

        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        ParentBeforeMoving = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
       transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        transform.SetParent(ParentBeforeMoving);
        Debug.Log(ParentBeforeMoving);
        image.raycastTarget = true;
    }

    public void UseItem()
    {

        switch (item.itemType)
        {
            case Item.ItemType.axe:
                Debug.Log("Axe");
                break;
            case Item.ItemType.IronIngot:
                Debug.Log("IronIngot");
                Count--;
                RefreshCount();
                break;
            case Item.ItemType.sword:
                Debug.Log("Sword");
                break;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        image.raycastTarget = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.raycastTarget = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }
}
