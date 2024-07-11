using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{



    public static InventoryManager Instance { get; private set; }

    public ItemSlot[] itemSlots;
    public GameObject InventoryItemPrefab;


    private void Awake()
    {
        Instance = this;
    }
    public bool AddItem(Item item)
    {

        for (int i = 0; i < itemSlots.Length; i++)
        {
            ItemSlot slot = itemSlots[i];
            InventoryItem inventoryItem = slot.GetComponentInChildren<InventoryItem>();
            if (inventoryItem != null
                && inventoryItem.item == item
                  && inventoryItem.Count < 8)
            {
                inventoryItem.Count++;
                inventoryItem.RefreshCount();
                return true;
            }

        }

        for (int i = 0; i < itemSlots.Length; i++)
        {
            ItemSlot slot = itemSlots[i];
            InventoryItem inventoryItem = slot.GetComponentInChildren<InventoryItem>();
            if (inventoryItem == null)
            {
                SetItemInInventory(item, slot);
                return true;
            }

        }

        return false;
    }

    public void SetItemInInventory(Item item, ItemSlot slot)
    {
        GameObject InventoryItemGO = Instantiate(InventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = InventoryItemGO.GetComponent<InventoryItem>();
        inventoryItem.InatializeItem(item);
    }

    

}
