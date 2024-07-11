using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public Transform Prefab;
    public Sprite image;
    public ItemType itemType;
    public bool IsStackable;





    public enum ItemType
    {
        IronIngot,
        wood,
        coal,
        axe,
        Hazolnore,
        sword

    }
}
