using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Open_Close : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;
    [SerializeField] private GameObject InventoryIcon;

    private bool isClosed;

    private void Awake()
    {
        isClosed = true;
        Inventory.SetActive(false);
        InventoryIcon.SetActive(true);
    }

  

    private void Update()
    {

      

        if (Input.GetKeyUp(KeyCode.F))
        {
            if(isClosed)
            {
                OpenInventory();
                isClosed = false;
            }
            else
            {
                LockCursor();
                isClosed=true;
            }

        }
        else
        {
            isClosed = true ;
        }
      

    }

    private void OpenInventory()
    {
       
        Inventory.SetActive(true);
        InventoryIcon.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void LockCursor()
    {
        isClosed = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

  
}
