using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interaction : MonoBehaviour
{
    [SerializeField] private Transform[] InteractPoint = new Transform[3];
    [SerializeField] private float playerRadius = .5f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject InteractionKey;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int[] num = new int[3];

    private void Awake()
    {
        InteractionKey.SetActive(false);
    }
    private void Update()
    {
        
        for (int i = 0; i < InteractPoint.Length; i++)
        {

            num[i] = Physics.OverlapSphereNonAlloc(InteractPoint[i].position, playerRadius, colliders, layerMask);
            PickableItemSetup(num[i]);
        

        }

        if (num[0] == 0 && num[1]==0 )
        {

            InteractionKey.SetActive(false);
        }
        else
        {
            InteractionKey.SetActive(true);
        }

    }






        private void PickableItemSetup(int num)
        {
            if (num > 0)
            {

                if (colliders[0].TryGetComponent(out ItemController itemController))
                {
                    
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        InventoryManager.Instance.AddItem(itemController.item);
                        Destroy(colliders[0].gameObject);
                    }

                }

            }


        }


    }

    



