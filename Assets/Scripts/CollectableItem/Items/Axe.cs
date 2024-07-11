using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, I_itemUse
{
    public static Axe Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }
    public void Function()
    {
        Debug.Log("Axe Equipped");
    }
}
